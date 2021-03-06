﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController instance;
    public Text hittext;
    public float rockspeed = -1.5f;
    public bool hitornot = false;

    private int hit = 0;
	// Use this for initialization
	void Awake () {
		if (instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (hitornot == true)
        {
            hitornot = false;
        }
	}

    public void Hit()
    {
        hitornot = true;
        hit++;
        hittext.text = "Hit:" + hit.ToString();
    }

}
