using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public Sprite s1, s2;
    public MainGame mg;
    public Player1 p;

    private GameObject g1, g2, g3;
    private bool onTrigger;

    void Start()
    {
        onTrigger = false;
        g1 = GameObject.FindWithTag("DoorText");
        g2 = GameObject.FindWithTag("DoorPanel");
        g3 = GameObject.FindWithTag("DoorPanelText");
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
               EditorApplication.isPlaying = false;
           }
       }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (mg.locsLeft == 0)
        {
            g1.GetComponent<Text>().text = "Press action button to proceed.";
            onTrigger = true;
        }
        else
            g1.GetComponent<Text>().text = "Get all LOCs to open the door.";
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onTrigger = false;
        g1.GetComponent<Text>().text = "";
    }
}
