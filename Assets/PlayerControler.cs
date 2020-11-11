using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public bool Ground = false;
    public Transform GroundCheck;
    public float GroundRadius;
    public LayerMask IsGround;
    Rigidbody2D rb;
    Animator Anim;
    SpriteRenderer sr;
    public GameObject YouDead;
    public float speed;
    public float jumpForce;
    public LayerMask whatisLadder;
    
    
    [SerializeField] private float damage;
    [SerializeField] private float reboot;
    [SerializeField] private float attackRange;
    [SerializeField] private float health;
    [SerializeField] private Transform attackPose;
    [SerializeField] private LayerMask enemyMask;
    private bool attack = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        hp.theHelth = 100;


    }
    private void FixedUpdate()
    {


        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (Input.GetAxis("Horizontal") == 0)

            Anim.SetBool("Run", true);
        if (Input.GetAxis("Horizontal") != 0)
        {
           
            Anim.SetBool("Run", true);
            Anim.SetBool("Uron", false);
        }
        else { Anim.SetBool("Run", false); }

        if (Input.GetAxis("Horizontal") > 0)
            sr.flipX = false;
        else if (Input.GetAxis("Horizontal") < 0)
            sr.flipX = true;

        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, 1f, whatisLadder);

        if (hitinfo.collider != null)
        {
            if (Input.GetAxis("Vertical") != 0 )
            {
                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * speed);
                Anim.SetBool("Leder", true);
            }
        }
        else
        {
            Anim.SetBool("Leder", false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            attack = true;
            Attack();

        }


    }
    

     void Update()
    {
       
        Ground = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, IsGround);
           if (Input.GetKeyDown(KeyCode.Space) && Ground)
        {
            Anim.SetTrigger("Jump");
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D other )
    {
        if (other.tag == "Respawn")
        {
            YouDead.SetActive(true);
            hp.theHelth = 0;
            Colect.theCoins = 0;
            Keys.theKeys = 0;

        }
        if (other.tag == "Coins") 
        { 
            Colect.theCoins += 1;
           
            Destroy(other.gameObject);
        }
        if (other.tag == "Keys")
        {
            Keys.theKeys += 1;

            Destroy(other.gameObject);
        }
        if (other.tag == "Door"&& Keys.theKeys == 3 )
           
                {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
            
            
    }
    public void Attack()
    {
        if (attack == true)
        {
            attack = false;
            Anim.SetTrigger("Atacc");
            Collider2D[] enemiscToDamage = Physics2D.OverlapCircleAll(attackPose.position, attackRange, enemyMask);
            for (int i = 0; i < enemiscToDamage.Length; i++)
            {
                enemiscToDamage[i].GetComponent<Monster>().Damage(damage);
            }
            Invoke("AttackReset", reboot);
        }
    }
    public void Damage(float damage)
    {
        health -= damage;
        hp.theHelth = health;
        Anim.SetTrigger("Uron");
        Anim.SetBool("Run",false);


        if (health <= 0)
            Destroy(gameObject);

    }
    
	
   
	

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(GroundCheck.position, GroundRadius);
    }







}
