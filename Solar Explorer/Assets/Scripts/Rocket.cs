﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fizzyo;

public class Rocket : MonoBehaviour
{
    public float breathtime = 1.0f;
    public Text breathshow;
    public float unbreakabletime = 10.0f;
    private bool timeup = false;
    private Rigidbody2D rocket;
    private bool up = false;
    private Vector2 velocity = new Vector2(0, 160);
    private float timer;
    private bool isbreathing;
    private Collider2D c;
    private float unbreakable;
    private Animator anim;



    // Use this for initialization
    void Start()
    {
        c = GetComponent<Collider2D>();
        rocket = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timer = 0.0f;
        unbreakable = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeup == false)
        {
            if (FizzyoFramework.Instance.Device.ButtonDown())
            {
                if (up == true)
                {
                    rocket.MovePosition(rocket.position + velocity * Time.fixedDeltaTime);
                    up = false;
                }
                else
                {
                    rocket.MovePosition(rocket.position - velocity * Time.fixedDeltaTime);
                    up = true;
                }
            }
            if (c.enabled == true)
            {
                if (FizzyoFramework.Instance.Device.Pressure() >= 0.7)
                {
                    timer += Time.deltaTime;
                    breathshow.text = "breathing";
                    isbreathing = true;
                }
                else if (isbreathing == true)
                {
                    if (timer - breathtime < 0.33f && timer - breathtime > -0.33f)
                    {
                        breathshow.text = "Good breath!";
                        c.enabled = false;
                    }
                    else
                    {
                        breathshow.text = "Try again!";
                    }
                    isbreathing = false;
                    timer = 0.0f;
                }
            }
            else
            {
                breathshow.text = "Invincible!";
                anim.SetBool("Boosting", true);
                unbreakable += Time.deltaTime;
                if (unbreakable >= unbreakabletime)
                {
                    c.enabled = true;
                    breathshow.text = "Invincible over";
                    unbreakable = 0.0f;
                    anim.SetBool("Boosting", false);
                }
            }
        }
    }

    void OnCollisionEnter2D()
    {
        anim.SetTrigger("Blink");
    }
}

