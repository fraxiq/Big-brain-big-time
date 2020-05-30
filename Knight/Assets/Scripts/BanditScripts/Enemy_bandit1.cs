using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy_bandit1 : MonoBehaviour
{
    public Animator animator;
    public Transform reach;
    public LayerMask playerlayers;

    public float attackrange = 0.5f;
    public int attackDamage = 10;
    public float attackrate = 2f;
    

    public int maxHealth = 40;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

        

    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(reach.position, attackrange, playerlayers);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<PlayerCombat>().TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);

        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<EnemyAIPrime>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<BossAIPrime>().enabled = false;
        this.enabled = false;

    }
}
