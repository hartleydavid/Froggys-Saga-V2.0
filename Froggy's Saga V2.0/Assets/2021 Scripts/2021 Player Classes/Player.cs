using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    //public UI ui;
    public GameManager gm;

    public Attack_Type_Player attackType;

    public int fullHealth;
    private int currentHealth;
    public int lifes;
    private bool isInvincible;
    private readonly float INVINCIBLE_DURATION = 1.5f;

    private float deathAnimationTimer;
    private float attackAnimationTimer;
    private float tookDamageAnimationTimer;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;
        lifes = 3;
        UpdateAnimationClipTimes();
        attackType.FloatSetter(attackAnimationTimer);
        animator.SetBool("IsDead", false);//Change Bool value?

    }

    void Update()
    {
        
        if (Input.GetKeyDown("1")) Heal(20);
        if (Input.GetKey("2")) Hurt(90);

    }

    //If you walk into a enemy it deals 10 damage
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*Enemy enemyContact;
        if (collision.collider.GetComponent<Enemy>() != null)
        {
            enemyContact = collision.collider.GetComponent<Enemy>();
            Hurt(10);//Get the damage the enemy does!
        }*/
    }

    /* Adds health when the player picks up an item
     * that would heal them
     * @param health: the amount of health being added
     */
    public void Heal(int health)
    {
        //If the healing doesn't go over full
        if (currentHealth + health <= fullHealth)
        {
            //add the total amount of health
            currentHealth += health;
        }
        else
        {
            //Go to cap health
            currentHealth = fullHealth;
        }
        gm.PlayerHealthUpdate(currentHealth);
        //ui.UpdateInfo(currentHealth);    
    }

    /* Deals with case when the player gets hurt and loses health
     * Gets called from spikes or enemies
     * @param int damage: the amount of damage recieved
     */
    public void Hurt(int damage)
    {

        if (isInvincible) return; // if invincible don't get hurt! -- Exit case
        //Ternery statement that see's if the health after taking damage would be negative
        //If so, health is 0, if not take the damage like a champ
        currentHealth = currentHealth - damage < 0 ? 0 : currentHealth - damage;       
        gm.PlayerHealthUpdate(currentHealth);

        if (currentHealth == 0)
        {
            //Well you die :(
            StartCoroutine(Died());
            return; //exit case
        }
        //Get them invicibility frames!
        StartCoroutine("DamageFrames");

    }

    //Public method to encaplsates the Death() method
    /*public void DeathLogic()
    {
        Death();
    }*/

    /* The meathod death() is called when the player dies in some form of gameplay way
     * Either it being a falling off the map or loosing health?
     * bool died; wether or not the player had died
     */
    private void Death()
    {
        //transition.Died(GameObject.Find("Player").GetComponent<PlayerInfo>(), FindObjectOfType<HUD_Interface>(), manage);
        lifes--; //take off a life
        // full health
        currentHealth = fullHealth; 
        //Update the game 
        gm.PlayerDeath(lifes, fullHealth);
        isInvincible = false;
        //if Its a game over
        if (lifes < 0)
        {
            Debug.Log("Gama Ovar");
            //play game over scene!
            //manage.GameOver();
        }
    }

    public float GetCurrentHealth() { return currentHealth; }

    /* Coroutine that will start when the player dies
     * It will last 5 seconds and then the player is able to die once more
     */
    IEnumerator Died()
    {
        isInvincible = true;
        animator.SetBool("IsDead", true); // Start animation
        // animator.SetTrigger("Died");
        yield return new WaitForSeconds(deathAnimationTimer);
        Death();
        animator.SetBool("IsDead", false); // end animation

    }

    /*This Coroutine makes it so when the player gets hurt in any way
     * The player will be invinsible for a set duartion - can vary from start method
     */
    IEnumerator DamageFrames()
    {
        //Do invinciblilty frames!
        isInvincible = true;
        animator.SetBool("IsHurt", isInvincible); // Start animation
        yield return new WaitForSeconds(INVINCIBLE_DURATION); // Makes it so the player will be invincible for the duration of invincibleDuration
        isInvincible = false;
        animator.SetBool("IsHurt", isInvincible); // End animation
    }

    public void UpdateAnimationClipTimes()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Attack"://case "Attack":
                    attackAnimationTimer = clip.length;
                    break;
                case "Hit"://case "Hit":
                    tookDamageAnimationTimer = clip.length;
                    break;
                case "Death"://case "Death":
                    deathAnimationTimer = clip.length;
                    break;
            }
        }
    }
}