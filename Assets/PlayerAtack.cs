using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    private float timeBtwAtack;
    public float startTimeBtwAtack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    Animator Anim;
    


    void Start()
    {
        
        Anim = GetComponent<Animator>();
    }

     void Update()
    {
        if (timeBtwAtack <= 0) 
        {
        if (Input.GetKeyUp(KeyCode.F))
            {
                Anim.SetBool("Atacc", true);

                OnAttack();


        }
         timeBtwAtack = startTimeBtwAtack;
            
        }
         else
        {Anim.SetBool("Atacc", false);
            timeBtwAtack -= Time.deltaTime;
         }
      
    }
    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Monster>().Damage(damage);
            

        }
       
    }
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }


}


