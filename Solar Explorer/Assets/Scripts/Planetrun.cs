﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planetrun : MonoBehaviour {
    private Rigidbody2D mars2d;
    private Rigidbody2D jup2d;
    private Rigidbody2D sat2d;
    private Rigidbody2D ur2d;
    private Rigidbody2D nep2d;

    private Text marsMessage;
    private Text jupMessage;
    private Text satMessage;
    private Text urMessage;
    private Text nepMessage;

    private float startTime;

    public static float marsTime = 20f;
    public static float jupTime = 50f;
    public static float satTime = 80f;
    public static float urTime = 110f;
    public static float nepTime = 140f;

    private bool marsSpawned = false;
    private bool jupSpawned = false;
    private bool satSpawned = false;
    private bool urSpawned = false;
    private bool nepSpawned = false;

    public float textTime;

    private GameObject text;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        mars2d = GameObject.FindGameObjectWithTag("Mars").GetComponent<Rigidbody2D>();
        jup2d = GameObject.FindGameObjectWithTag("Jupiter").GetComponent<Rigidbody2D>();
        sat2d = GameObject.FindGameObjectWithTag("Saturn").GetComponent<Rigidbody2D>();
        ur2d = GameObject.FindGameObjectWithTag("Uranus").GetComponent<Rigidbody2D>();
        nep2d = GameObject.FindGameObjectWithTag("Neptune").GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        planetCheck();
    }

    void spawnMars()
    {
        mars2d.velocity = new Vector2(GameController.instance.rockspeed / 1.1f, 0);
        marsSpawned = true;
        marsMessage = GameObject.FindGameObjectWithTag("marsText").GetComponent<Text>();

    }
    void spawnJupiter()
    {
        jup2d.velocity = new Vector2(GameController.instance.rockspeed / 2, 0);
        jupSpawned = true;
    }
    void spawnSaturn()
    {
        sat2d.velocity = new Vector2(GameController.instance.rockspeed / 2, 0);
        satSpawned = true;

    }
    void spawnUranus()
    {
        ur2d.velocity = new Vector2(GameController.instance.rockspeed / 2, 0);
        urSpawned = true;

    }
    void spawnNeptune()
    {
        nep2d.velocity = new Vector2(GameController.instance.rockspeed / 2, 0);
        nepSpawned = true;
    }

    void planetCheck()
    {
        if (Time.time - startTime > marsTime && marsSpawned == false)
        {
            spawnMars();
        }
        if (Time.time - startTime > jupTime && jupSpawned == false)
        {
            spawnJupiter();
        }
        if (Time.time - startTime > satTime && satSpawned == false)
        {
            spawnSaturn();
        }
        if (Time.time - startTime > urTime && urSpawned == false)
        {
            spawnUranus();
        }
        if (Time.time - startTime > nepTime && nepSpawned == false)
        {
            spawnNeptune();
        }

    }
}
