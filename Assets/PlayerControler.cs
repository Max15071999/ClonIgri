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
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
       

    }
    private void FixedUpdate()
    {


        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 5f, rb.velocity.y);

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
            rb.AddForce(transform.up * 8, ForceMode2D.Impulse);

        }  
    }
    private void OnTriggerEnter2D(Collider2D other )
    {
        if (other.tag == "Respawn")
        {

            SceneManager.LoadScene(0);

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
