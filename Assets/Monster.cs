using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed;
    public int positionOfPatrol;
    public Transform point;
    bool moveingRight = true;
    Transform player;
    bool chill = false;
    bool angry = false;
    bool goback = false;
    SpriteRenderer sr;
    Animator Ghoul;
    [Header("Урон")]
    [Space]
    [SerializeField] private float damage;
    [SerializeField] private float reboot;
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPose;
    [SerializeField] private LayerMask enemyMask;
    private bool attack = true;
    public float AngryPosition;
    [SerializeField] private float health;

    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Ghoul = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position) < AngryPosition)
        {
            angry = true;
            chill = false;
            goback = false;
        }
        if (Vector2.Distance(transform.position, player.position) > AngryPosition)
        {
            goback = true;
            angry = false;
        }


        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goback == true)
        {
            GoBack();
        }
    }
    void Chill()
    {
        speed = 2;
        Ghoul.SetBool("idle", true);
        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            moveingRight = false;
            sr.flipX = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            moveingRight = true;
            sr.flipX = true;
        }
        if (moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

    }
    void Angry()
    {
        Attack();
        Ghoul.SetBool("Atack", true);
        Ghoul.SetBool("idle", false);
        Ghoul.SetBool("Death", false);

        if (transform.position.x < player.transform.position.x)
            sr.flipX = true;
        else if ((transform.position.x > player.transform.position.x))
            sr.flipX = false;

    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);

        if (transform.position.x < point.transform.position.x)
            sr.flipX = true;
        else if ((transform.position.x > point.transform.position.x))
            sr.flipX = false;




        Ghoul.SetBool("idle", true);
        Ghoul.SetBool("Death", false);
    }
 
    public void Attack()
    {
        if (attack == true)
        {
            attack = false;
            Ghoul.SetTrigger("Atack");
            Collider2D[] enemiscToDamage = Physics2D.OverlapCircleAll(attackPose.position, attackRange, enemyMask);
            for (int i = 0; i < enemiscToDamage.Length; i++)
            {
                enemiscToDamage[i].GetComponent<PlayerControler>().Damage(damage);
            }
            Invoke("AttackReset", reboot);
        }
    }
    private void AttackReset()
    {
        attack = true;
    }


    public void Damage(float damage)
    {
        health -= damage;
        Ghoul.SetTrigger("Uron");
        if (health <= 0)
            Destroy(gameObject);
       
    }
 
}
