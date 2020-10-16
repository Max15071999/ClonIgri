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
    public int health;
    public float AngryPosition;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Ghoul = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        if (health<=0)
        {
            Colect.theCoins += 10;
            Destroy(gameObject);
            
        }
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill=true;
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
        Ghoul.SetInteger("Ghoul", 0);
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
        else {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
              }
       
    }
    void Angry()
    { Ghoul.SetInteger("Ghoul", 1);
       
        if (transform.position.x < player.transform.position.x)
            sr.flipX = true;
          else if ( (transform.position.x > player.transform.position.x))
            sr.flipX = false;
       
    }
    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);

        if (transform.position.x < point.transform.position.x)
            sr.flipX = true;
        else if ((transform.position.x > point.transform.position.x))
            sr.flipX = false;




        Ghoul.SetInteger("Ghoul", 0);
       
    }
    public void TakeDamage( int damage)
    {
        health -= damage;
    }
}
