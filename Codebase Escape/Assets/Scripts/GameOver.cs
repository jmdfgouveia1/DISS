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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(g1);
            SceneManager.LoadSceneAsync("Scene1");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(g1);
            SceneManager.LoadSceneAsync("MainMenu");
        }
    }
}
