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
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
       

    }
    private void FixedUpdate()
    {


        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (Input.GetAxis("Horizontal") == 0)
            Anim.SetInteger("Anim", 0);

        if (Input.GetAxis("Horizontal") != 0)
            Anim.SetInteger("Anim", 1);

        if (Input.GetAxis("Horizontal") > 0)
            sr.flipX = false;
        else if (Input.GetAxis("Horizontal") < 0)
            sr.flipX = true;

       


    }
    

     void Update()
    {
       
        Ground = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, IsGround);
           if (Input.GetKeyDown(KeyCode.Space) && Ground)
        {

            Anim.SetInteger("Anim", 2);
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);

        }
       
        
    }
    private void OnTriggerEnter2D(Collider2D other )
    {
        if (other.tag == "Respawn")
        {
            YouDead.SetActive(true);


            Colect.theCoins = 0;

        }
        if (other.tag == "Coins") 
        { 
            Colect.theCoins += 1;
            Debug.Log("on trigger coins");
            Destroy(other.gameObject);
        }     
    }
       
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(GroundCheck.position, GroundRadius);
    }







}
