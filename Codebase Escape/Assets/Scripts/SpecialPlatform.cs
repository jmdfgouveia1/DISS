using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPlatform : MonoBehaviour {

    private GameObject g;
    private MainGame mg;

	// Use this for initialization
	void Start () {
        g = GameObject.FindWithTag("GameController");
        mg = g.GetComponent<MainGame>();
	}
	
	// Update is called once per frame
	void Update () {
		if (mg.locsLeft == 0)
        {
            if (gameObject.tag == "SpecialPlatform1")
                IsItEnabled(true);
            else if (gameObject.tag == "SpecialPlatform2")
                IsItEnabled(false);
        }
        else
        {
            if (gameObject.tag == "SpecialPlatform1")
                IsItEnabled(false);
            else if (gameObject.tag == "SpecialPlatform2")
                IsItEnabled(true);
        }
	}

    void IsItEnabled(bool b)
    {
        GetComponent<SpriteRenderer>().enabled = b;
        GetComponent<BoxCollider2D>().enabled = b;
    }

}
