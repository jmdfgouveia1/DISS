﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DOC : MonoBehaviour {

    private GameObject g1, g2, g3, g4;
    private bool onTrigger;
    private MainGame mg;

    public Player1 p;
    public string text1, text2;

    void Start ()
    {
        g1 = GameObject.FindWithTag("DocText");
        g2 = GameObject.FindWithTag("DocPanel");
        g3 = GameObject.FindWithTag("DocPanelText");
        g4 = GameObject.FindWithTag("GameController");
        mg = g4.GetComponent<MainGame>();
        onTrigger = false;
        g2.GetComponent<Image>().enabled = false;
        g3.GetComponent<Text>().enabled = false;
        g3.GetComponent<Text>().fontSize = 42;
    }

    void Update ()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            text1 = "Software architecture is a subtopic of the Software Engineering domain of knowledge and can be defined as the specification of the structure of a software system.";
            g3.GetComponent<Text>().text = text1;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        { 
            text1 = "Structural issues that software architecture is meant to address include the following:\n\nGross organization and global control structure; protocols for communication, synchronization and data access; and assignment of functionality to design elements.";
            text2 = "Structural issues that software architecture is meant to address include the following:\n\nPhysical distribution; composition of design elements; scaling and performance; and selection among design alternatives.";
            DifferentDocsDifferentTexts(text1, text2);
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            text1 = "Software architecture is important because it helps us understand large systems easily and it contributes to the reuse of large components and the frameworks in which they can be integrated.";
            text2 = "The importance of software architecture is that it provides a partial blueprint for a software system's development by explicitly indicating its components and dependencies between them and it exposes the ways in which said system is expected to evolve.";
            DifferentDocsDifferentTexts(text1, text2);
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            text1 = "Architecture Description Languages (ADLs) are notations responsible for characterizing software architectures, typically also providing tools for parsing and generating architecture descriptions.\n\nDistinct examples of ADLs include Adage, Aesop, C2, Darwin, Rapide, SADL, UniCon, Meta-H and Wright.";
            text2 = "There are different models (also known as styles or patterns) for architecture design. These models typically specify a design vocabulary, restrictions on how that vocabulary is employed and semantic assumptions about that vocabulary.\n\nDistinct examples of architectural models include pipe-and-filter, blackboard, client-server, event-based and object-based.";
            DifferentDocsDifferentTexts(text1, text2);
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            text1 = "Some examples of software architectures are as follows:\n\nThe International Standard Organization's Open Systems Interconnection Reference Model, a layered network architecture;\nThe NIST/ECMA Reference Model, a generic software engineering environment architecture based on layered communication substrates;\nThe X Window System, a distributed windowed user interface architecture based on event triggering and callbacks.";
            text2 = "Another example of a software architecture is Camelot, which is built using the client-server model and uses remote procedure calls both locally and remotely to provide communication among applications and servers.";
            DifferentDocsDifferentTexts(text1, text2);
        }


        if (Input.GetKeyDown(KeyCode.Return) && onTrigger && Time.timeScale == 1)
        {
            if (!g2.GetComponent<Image>().enabled)
            {
                g2.GetComponent<Image>().enabled = true;
                g3.GetComponent<Text>().enabled = true;
                mg.activePanel = true;
                p.movement = false;
            }
            else
            {
                g2.GetComponent<Image>().enabled = false;
                g3.GetComponent<Text>().enabled = false;
                mg.activePanel = false;
                p.movement = true;
            }
        }
    }
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (SceneManager.GetActiveScene().name == "Level1")
            g1.GetComponent<Text>().text = "Press action button to read doc.";
        onTrigger = true;    
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onTrigger = false;
        g1.GetComponent<Text>().text = "";
    }

    void DifferentDocsDifferentTexts(string s1, string s2)
    {
        if (gameObject.tag == "Doc1")
            g3.GetComponent<Text>().text = s1;
        else if (gameObject.tag == "Doc2")
            g3.GetComponent<Text>().text = s2;
    }
}
