using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CQC_Attack_Player : Attack_Type_Player
{
    private string attackName = "Close Quarters";
    public float range;
    public float damageFrame;//Is the attack speed, the frame of damage is the speed in which the player attacks

    private bool didAttack;
    private float attackDuration;
    //public float damageFrame;//Is the attack speed, the frame of damage is the speed in which the player attacks



    //Draws a circle for the hitbox
    /*private void OnDrawGizmosSelected()
   {
       Gizmos.DrawWireSphere(attackPoint.position, range);
   }*/

    override
    public void FloatSetter(float attackDuration)
    {
        this.attackDuration = attackDuration;//Mathf.Round(attackDuration * 1000.0f) / 1000.0f;//Mathf.Floor(attackDuration);
    }

    override
    public void Attack()
    {
        if (!didAttack)
        {
            //play animation - Includes cooldown
            StartCoroutine(DamageFrameTimer());
            StartCoroutine(AttackAnimation());

        }
    }

    //Times the exact frame that the player would do damage
    IEnumerator DamageFrameTimer()
    {
        yield return new WaitForSeconds(damageFrame);
        DoDamageFrame();
    }

    private void DoDamageFrame()
    {
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayer);

        foreach (Collider2D enemy in hitenemies)
        {
            //enemy.GetComponent<Enemy>().Hurt(CalculateDamage());
        }

    }

    override
    public IEnumerator AttackAnimation()
    {
        didAttack = true;
        animator.SetBool("Swing", didAttack);
        yield return new WaitForSeconds(attackDuration);
        didAttack = false;
        animator.SetBool("Swing", didAttack);
    }

    public override string getAttackName()
    {
        return attackName;
    }
}
