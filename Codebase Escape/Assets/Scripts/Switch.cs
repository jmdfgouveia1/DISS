using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour {

    public Sprite s1, s2;
    public string t;

    private GameObject p, gc, st;
    private GameObject[] gs;
    private MainGame mg;
    private bool onTrigger;

	// Use this for initialization
	void Start () {
        gs = GameObject.FindGameObjectsWithTag(t);
        p = GameObject.FindWithTag("Player");
        gc = GameObject.FindWithTag("GameController");
        st = GameObject.FindWithTag("SwitchText");
        mg = gc.GetComponent<MainGame>();
        onTrigger = false;
        GetComponent<SpriteRenderer>().sprite = s1;
        foreach (GameObject g in gs)
            g.GetComponent<MovingPlatform>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) && onTrigger && !mg.paused)
        {
            if (GetComponent<SpriteRenderer>().sprite == s1)
            {
                GetComponent<SpriteRenderer>().sprite = s2;
                st.GetComponent<Text>().text = "";
                foreach (GameObject g in gs)
                    g.GetComponent<MovingPlatform>().enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (p == other.gameObject)
        {
            if (gameObject.tag == "FirstSwitch" && GetComponent<SpriteRenderer>().sprite == s1)
                st.GetComponent<Text>().text = "Press the switch and something will happen.";
        }
            onTrigger = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (p == other.gameObject)
        {
            st.GetComponent<Text>().text = "";
            onTrigger = false;
        }
    }
}
