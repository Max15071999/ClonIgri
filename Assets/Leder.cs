using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leder : MonoBehaviour
{

    private float inputVertical;
    public float speed;
    Rigidbody2D rb;
    public float distance;
    public LayerMask whatisLadder;
    private bool Climbing;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatisLadder);

        if (hitinfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Climbing = true;
            }
        }
        else
        {
            Climbing = false;
        }

        if (Climbing == true && hitinfo.collider != null)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.position.x, inputVertical * speed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 2;
        }
    }
}
