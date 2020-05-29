using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform PointNaShpaga;
    public LayerMask enemylayers;

    public float attackrange = 0.5f;
    public int attackDamage = 20;
    public float attackrate;
    float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackrate;
            }
        }
        
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PointNaShpaga.position,attackrange, enemylayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_bandit1>().TakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (PointNaShpaga == null)
            return;
        Gizmos.DrawWireSphere(PointNaShpaga.position, attackrange);
        
    }

}
