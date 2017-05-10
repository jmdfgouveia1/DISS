using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private GameObject g1;

	// Use this for initialization
	void Start ()
    {
        g1 = GameObject.FindWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Destroy(g1);
            SceneManager.LoadSceneAsync("Tome1");
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            Destroy(g1);
            SceneManager.LoadSceneAsync("MainMenu");
        }
    }
}
