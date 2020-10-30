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
    private bool _isClimbing;


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
            Anim.SetInteger("Anim", 0);

        if (Input.GetAxis("Horizontal") != 0)
        {
           
            Anim.SetBool("Run", true);
        }
        else { Anim.SetBool("Run", false); }

        if (Input.GetAxis("Horizontal") > 0)
            sr.flipX = false;
        else if (Input.GetAxis("Horizontal") < 0)
            sr.flipX = true;

        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, 1f, whatisLadder);

        if (hitinfo.collider != null)
        {
            Debug.Log("=== true");
            _isClimbing = true;
        }
        else
        {
            _isClimbing = false;
        }


    }
    

     void Update()
    {
       
        Ground = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, IsGround);
           if (Input.GetKeyDown(KeyCode.Space) && Ground)
        {
 

            Anim.SetTrigger("Jump");
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);


       
            Anim.SetInteger("Anim",4);
            
 
        }
       
        
    }
    private void OnTriggerEnter2D(Collider2D other )
    {
        if (other.tag == "Respawn")
        {
            YouDead.SetActive(true);
            hp.theHelth = 0;
            Colect.theCoins = 0;

        }
        if (other.tag == "Coins") 
        { 
            Colect.theCoins += 1;
           
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Lader"))
        {
            if (Input.GetAxis("Vertical") != 0 && _isClimbing)
            {
                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * speed);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Lader") )
        {
            if (Input.GetAxis("Vertical") != 0 && _isClimbing)
            {
                rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * speed);
                Anim.SetBool("Leder", true);
            }
           
        }
        else
        {
            Anim.SetBool("Leder", false);
        }

        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(GroundCheck.position, GroundRadius);
    }







}
