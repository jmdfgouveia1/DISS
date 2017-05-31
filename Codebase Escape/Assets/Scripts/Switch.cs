using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour {

    public string t;

    private Color c1, c2;
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
        c1 = new Color(1, 1, 1, 1);
        c2 = new Color(0.5f, 0.5f, 0.5f, 1);
        foreach (GameObject g in gs)
            g.GetComponent<MovingPlatform>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag == "HiddenSwitch")
        {
            if (mg.locsLeft > 0)
                GetComponent<SpriteRenderer>().enabled = false;
            else
                GetComponent<SpriteRenderer>().enabled = true;
        }

        if (Input.GetButtonDown("Fire1") && onTrigger && Time.timeScale == 1 && GetComponent<SpriteRenderer>().enabled)
        {
            if (GetComponent<SpriteRenderer>().color == c1)
            {
                if (SceneManager.GetActiveScene().name == "Level3")
                    st.GetComponent<Text>().text = "";
                GetComponent<SpriteRenderer>().color = c2;
                GetComponent<AudioSource>().Play();
                foreach (GameObject g in gs)
                    g.GetComponent<MovingPlatform>().enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (p == other.gameObject)
        {
            if (gameObject.tag == "FirstSwitch" && GetComponent<SpriteRenderer>().color == c1 && SceneManager.GetActiveScene().name == "Level3")
                st.GetComponent<Text>().text = "Press the switch and something will happen.";
        }
            onTrigger = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (p == other.gameObject)
        {
            if (SceneManager.GetActiveScene().name == "Level3")
                st.GetComponent<Text>().text = "";
            onTrigger = false;
        }
    }
}
