using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelIdentifier : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "Level1")
            GetComponent<Text>().text = "Level 1";
        else if (SceneManager.GetActiveScene().name == "Level2")
            GetComponent<Text>().text = "Level 2";
        else if (SceneManager.GetActiveScene().name == "Level3")
            GetComponent<Text>().text = "Level 3";
        else if (SceneManager.GetActiveScene().name == "Level4")
            GetComponent<Text>().text = "Level 4";
        else if (SceneManager.GetActiveScene().name == "Level5")
            GetComponent<Text>().text = "Level 5";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
