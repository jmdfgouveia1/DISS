﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DOC : MonoBehaviour {

    private GameObject g1, g2, g3;
    private bool onTrigger;

    public Player1 p;
    public MainGame mg;

    void Start ()
    {
        g1 = GameObject.FindWithTag("DocText");
        g2 = GameObject.FindWithTag("DocPanel");
        g3 = GameObject.FindWithTag("DocPanelText");
        onTrigger = false;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return) && onTrigger && !mg.paused)
        {
            if (!g2.GetComponent<Image>().enabled)
            {
                g2.GetComponent<Image>().enabled = true;
                g3.GetComponent<Text>().enabled = true;
                p.movement = false;
            }
            else
            {
                g2.GetComponent<Image>().enabled = false;
                g3.GetComponent<Text>().enabled = false;
                p.movement = true;
            }
        }
    }
	
    void OnTriggerEnter2D(Collider2D other)
    {
        g1.GetComponent<Text>().text = "Press action button to read doc.";
        onTrigger = true;    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onTrigger = false;
        g1.GetComponent<Text>().text = "";
    }

}