using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour {

    public int locsLeft;
    public int score;
    public bool paused;

	// Use this for initialization
	void Start () {
        score = 5000;
        locsLeft = 5;
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                paused = true;
                Time.timeScale = 0;
            }
                
            else
            {
                Time.timeScale = 1;
                paused = false;
            }
                
        }

        if (Input.GetKeyDown(KeyCode.R) && Time.timeScale == 1)
            SceneManager.LoadScene(0);

        if (score > 0 && Time.timeScale == 1)
            score--;
	}
}
