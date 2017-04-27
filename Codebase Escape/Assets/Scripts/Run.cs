using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Run : MonoBehaviour {

    private GameObject g;
    private MainGame mg;

	// Use this for initialization
	void Start () {
        g = GameObject.FindWithTag("GameController");
        mg = g.GetComponent<MainGame>();
        GetComponent<Text>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (mg.locsLeft == 0)
            GetComponent<Text>().enabled = true;
    }
}
