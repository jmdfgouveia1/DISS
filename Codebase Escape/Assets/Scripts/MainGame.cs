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

        DontDestroyOnLoad(gameObject);

        if (SceneManager.GetActiveScene().name == "Level1")
            score = 5000;

        paused = false;

        locsLeft = 5;
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
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadSceneAsync("Level1");
                Destroy(gameObject);
            }  
            else if (SceneManager.GetActiveScene().name == "Level2")
                SceneManager.LoadSceneAsync("Level2");
        }

        if (score > 0 && Time.timeScale == 1)
            score--;
	}
}
