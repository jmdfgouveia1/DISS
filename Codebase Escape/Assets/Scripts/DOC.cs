using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DOC : MonoBehaviour {

	
    void OnTriggerEnter2D(Collider2D other)
    {
        GetComponent<Text>().text = "Press action button to read doc.";
    }

}
