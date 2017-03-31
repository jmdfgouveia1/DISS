using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public Sprite s1, s2;
    public Player1 p;

    private MainGame mg;
    private GameObject g1, g2, g3, g4;
    private bool onTrigger;

    void Start()
    {
        onTrigger = false;
        g1 = GameObject.FindWithTag("DoorText");
        g2 = GameObject.FindWithTag("DoorPanel");
        g3 = GameObject.FindWithTag("DoorPanelText");
        g4 = GameObject.FindWithTag("GameController");
        mg = g4.GetComponent<MainGame>();
    }

    // Update is called once per frame
    void Update () {
        if (mg.locsLeft > 0)
            GetComponent<SpriteRenderer>().sprite = s1;
        else
            GetComponent<SpriteRenderer>().sprite = s2;

       if (!g2.GetComponent<Image>().enabled)
       {
            if (Input.GetKeyDown(KeyCode.Return) && onTrigger && !mg.paused)
            {
                g2.GetComponent<Image>().enabled = true;
                g3.GetComponent<Text>().enabled = true;
                p.movement = false;
            }
       }
       else
       {
           if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Return)) && !mg.paused)
           {
               g2.GetComponent<Image>().enabled = false;
               g3.GetComponent<Text>().enabled = false;
               p.movement = true;
           }
           else if (Input.GetKeyDown(KeyCode.D))
           {
               p.movement = true;
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    SceneManager.LoadScene("Level2");
                    mg.locsLeft = 6;
                }
                else if (SceneManager.GetActiveScene().name == "Level2")
                    Application.Quit();

                mg.score += 5000;
           }
       }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (mg.locsLeft == 0)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
                g1.GetComponent<Text>().text = "Press action button to proceed.";
            onTrigger = true;
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Level1")
                g1.GetComponent<Text>().text = "Get all LOCs to open the door.";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onTrigger = false;
        g1.GetComponent<Text>().text = "";
    }
}
