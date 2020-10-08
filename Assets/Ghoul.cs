﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghoul : MonoBehaviour
{
    SpriteRenderer sr;
    Animator anim;
    Rigidbody2D rb;
    public int distance;
    float maxDistance;
    float minDistance;
    int speed = 1;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        maxDistance = transform.position.x + distance;
        minDistance = transform.position.x - distance;
    }
    private void FixedUpdate()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
        if (transform.position.x > maxDistance)
        {
            speed = -speed;
            sr.flipX = false;
        }
        if (transform.position.x < minDistance)
        {
            speed = -speed;
            sr.flipX = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
