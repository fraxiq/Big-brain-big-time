using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform PointNaShpaga;
    public LayerMask enemylayers;

    public float attackrange = 0.5f;
    public int attackDamage = 20;
    public float attackrate = 2f;
    float nextAttackTime = 0f;
    

    public int maxHealth = 100;
    public int CurrHealth;
    public bool TookDmg = false;

    void Start()
    {
        CurrHealth = maxHealth;
    }

    void Update()
    {
        if (Time.time>= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackrate;
            }
        }
        


    }
    
    public  void TakeDamage(int damage)
    {
        CurrHealth -= damage;
        animator.SetTrigger("hurt");
        TookDmg = true;
        if (CurrHealth <= 0)
        {
            Die();
        }
        
    }
    

    void Die()
    {
        animator.SetBool("Isdead",true);

        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<CharacterController2D>().enabled = false;
        GetComponent<Dash>().enabled = false;
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        this.enabled = false;



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
