using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack_Type_Player : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer;

    public float damage;
    public float critChance;
    public float critMultiplier;


    
    //Abstract methods that all subclasses must include
    public abstract void Attack();
    public abstract IEnumerator AttackAnimation();
    //Special case method
    public abstract void FloatSetter(float value);

    //Method calculates the damage output on attack
    //TODO: Damage multiplier (power-up)? 
    public float CalculateDamage()
    {
        float attackDamage;
        //find if crit
        if (Random.Range(0, 100) < critChance)
        {
            Debug.Log("CRIT");
            //do damage with crit
            attackDamage = damage * critMultiplier;
        }
        else
        {
            //if no crit, normal damage
            attackDamage = damage;
        }
        return attackDamage;
    }

}
