using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LOCIdentifier : MonoBehaviour {

    private GameObject g;
    private MainGame mg;

    // Use this for initialization
    void Start()
    {
        g = GameObject.FindWithTag("GameController");
        mg = g.GetComponent<MainGame>();

        GetComponent<Text>().text = "LOCs Left: " + mg.locsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "LOCs Left: " + mg.locsLeft;
    }
}
