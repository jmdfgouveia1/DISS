using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour {

    public int locsLeft;
    public int score;
    public float moveSpeed;
    public float jumpPower;
    public int healthPoints;
    public bool paused;

    private GameObject g1, g2, g3, g4, g5, g6, g7;
    private bool gameOver;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

        score = 5000;
        paused = false;
        //locsLeft = 5;
        moveSpeed = 20f;
        jumpPower = 20f;
        healthPoints = 3;
        
        g1 = GameObject.FindWithTag("HPCount");
        g2 = GameObject.FindWithTag("GameOverPanel");
        g3 = GameObject.FindWithTag("GameOverPanelText");
        g4 = GameObject.FindWithTag("Player");
        g5 = GameObject.FindWithTag("DuplicateFoe1");
        g6 = GameObject.FindWithTag("DuplicateFoe2");
        g7 = GameObject.FindWithTag("DuplicateFoe3");

        g2.GetComponent<Image>().enabled = false;
        g3.GetComponent<Text>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
        {
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
                    Restart();
                else if (SceneManager.GetActiveScene().name == "Level2")
                {
                    SceneManager.LoadSceneAsync("Level2");
                    locsLeft = 6;
                }
            }
        }

        g1.GetComponent<Text>().text = healthPoints.ToString();

        if (score > 0 && Time.timeScale == 1)
            score--;

        if (healthPoints == 0)
        {
            gameOver = true;
            g2.GetComponent<Image>().enabled = true;
            g3.GetComponent<Text>().enabled = true;
            g4.GetComponent<Player1>().movement = false;
            g5.GetComponent<Foe>().movement = false;
            g6.GetComponent<Foe>().movement = false;
            g7.GetComponent<Foe>().movement = false;

            if (Input.GetKeyDown(KeyCode.Return))
                Restart();
            else if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
	}

    void Restart()
    {
        SceneManager.LoadSceneAsync("Level1");
        Destroy(gameObject);
    }
}
