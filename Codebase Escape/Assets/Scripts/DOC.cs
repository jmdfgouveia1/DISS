using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DOC : MonoBehaviour {

    private GameObject g;

    void Start ()
    {
        g = GameObject.FindWithTag("DocText");
    }
	
    void OnTriggerEnter2D(Collider2D other)
    {
        g.GetComponent<Text>().text = "Press action button to read doc.";
    }

    void OnTriggerExit2D(Collider2D other)
    {
        g.GetComponent<Text>().text = "";
    }

}
