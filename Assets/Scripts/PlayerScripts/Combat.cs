using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;
    public LayerMask enemylayers;
    private Vector3 playerPos;
    private Vector3 enemyPos;
    public GameObject Enemy;
    public Transform Weapon;
    public float enemyAttackRange;
    public float attackrange = 0.5f;
    public int attackDamage = 20;
    public float attackrate;
    float nextAttackTime = 0f;
    void Start()
    {
        
    }
    void EnemyAttack()
    {
       
        animator.SetTrigger("Attack");

        nextAttackTime = Time.time + 1f / attackrate;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(Weapon.position, attackrange, enemylayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            //   enemy.GetComponent<PlayerStats>().TakeDamage(attackDamage);
            return;
        }

    }


    void Update()
    {
        playerPos = transform.position;
        enemyPos = Enemy.transform.position;
        float playerX = playerPos.x;
        float enemyX = enemyPos.x;


   

        if (Time.time >= nextAttackTime)
        {
            if (Mathf.Abs(playerX - enemyX) <= enemyAttackRange)
            {
                Debug.Log("Ataka");

                EnemyAttack();
                nextAttackTime = Time.time + 1f / attackrate;
                        
            }
       
        }
    }
}
