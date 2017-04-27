using System.Collections;
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
            text1 = "Structural issues that software architecture is meant to address include the following:\n\nGross organization and global control structure; protocols for communication, synchronization and data access; assignment of functionality to design elements; physical distribution; composition of design elements; scaling and performance; and selection among design alternatives.";
            g3.GetComponent<Text>().text = text1;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            text1 = "The text is red but the background is blue;";
            text2 = "The text is red but the background is blue:";
            if (gameObject.tag == "Doc1")
                g3.GetComponent<Text>().text = text1;
            else if (gameObject.tag == "Doc2")
                g3.GetComponent<Text>().text = text2;
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            text1 = "The text is red but the background is blue.";
            text2 = "The text is red but the background is blue.";
            if (gameObject.tag == "Doc1")
                g3.GetComponent<Text>().text = text1;
            else if (gameObject.tag == "Doc2")
                g3.GetComponent<Text>().text = text2;
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            text1 = "The text is red but the background is blue.";
            text2 = "The text is red but the background is blue.";
            if (gameObject.tag == "Doc1")
                g3.GetComponent<Text>().text = text1;
            else if (gameObject.tag == "Doc2")
                g3.GetComponent<Text>().text = text2;
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

}
