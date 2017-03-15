using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public Sprite s1, s2;
    public MainGame mg;

    private GameObject g;

    void Start()
    {
        g = GameObject.FindWithTag("DoorText");
    }

    // Update is called once per frame
    void Update () {
        if (mg.locsLeft > 0)
            GetComponent<SpriteRenderer>().sprite = s1;
        else
            GetComponent<SpriteRenderer>().sprite = s2;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (mg.locsLeft == 0)
            g.GetComponent<Text>().text = "Press action button to proceed.";
        else
            g.GetComponent<Text>().text = "Get all LOCs to open the door.";
    }

    void OnTriggerExit2D(Collider2D other)
    {
        g.GetComponent<Text>().text = "";
    }
}
