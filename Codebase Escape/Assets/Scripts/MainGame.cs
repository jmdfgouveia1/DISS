using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGame : MonoBehaviour {

    public int locsLeft;
    public int score;
    public float moveSpeed, resetMoveSpeed;
    public float jumpPower, resetJumpPower;
    public int healthPoints;
    public bool immunity, success, activePanel;
    //public bool upgrade1, upgrade2, upgrade3, upgrade4;
    public List<string> texts;

    private GameObject g1, g2, g3, g4, g5, g6;
    private Player1 p;
    private SpriteRenderer sr;
    private int i;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

        score = 5000;
        immunity = false;
        success = false;
        activePanel = false;
        //locsLeft = 5;
        moveSpeed = 20f;
        resetMoveSpeed = moveSpeed;
        jumpPower = 20f;
        resetJumpPower = jumpPower;
        healthPoints = 3;
        i = 0;
        texts = new List<string>();
    }
	
	// Update is called once per frame
	void Update () {
        g1 = GameObject.FindWithTag("HPCount");
        g2 = GameObject.FindWithTag("PausePanel");
        g3 = GameObject.FindWithTag("PausePanelText");
        g4 = GameObject.FindWithTag("Player");
        g5 = GameObject.FindWithTag("PDocsPanel");
        g6 = GameObject.FindWithTag("PDocsPanelText");

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (g2)
            {
                g3.GetComponent<Text>().fontSize = 72;

                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    g2.GetComponent<Image>().enabled = true;
                    g3.GetComponent<Text>().enabled = true;
                }

                else
                {
                    g2.GetComponent<Image>().enabled = false;
                    g3.GetComponent<Text>().enabled = false;
                    Time.timeScale = 1;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && Time.timeScale == 0)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadSceneAsync("Level1");
                Destroy(gameObject);
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
                ResetLevel("Level2", 6);
            else if (SceneManager.GetActiveScene().name == "Level3")
                ResetLevel("Level3", 7);
            else if (SceneManager.GetActiveScene().name == "Level4")
                ResetLevel("Level4", 8);
            else if (SceneManager.GetActiveScene().name == "Level5")
                ResetLevel("Level5", 1);

            moveSpeed = resetMoveSpeed;
            jumpPower = resetJumpPower;
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            SceneManager.LoadSceneAsync("MainMenu");
            Time.timeScale = 1;
            Destroy(gameObject);
        }

        if (g4)
        {
            p = g4.GetComponent<Player1>();
            sr = g4.GetComponent<SpriteRenderer>();

            if (g5)
            {
                g6.GetComponent<Text>().fontSize = 42;

                if (Input.GetKeyDown(KeyCode.M) && Time.timeScale == 1 && !activePanel)
                {
                    if (!g5.GetComponent<Image>().enabled)
                    {
                        g5.GetComponent<Image>().enabled = true;
                        g6.GetComponent<Text>().enabled = true;
                        p.movement = false;
                    }
                    else
                    {
                        g5.GetComponent<Image>().enabled = false;
                        g6.GetComponent<Text>().enabled = false;
                        p.movement = true;
                    }
                }

                if (g5.GetComponent<Image>().enabled)
                {
                    if (SceneManager.GetActiveScene().name == "Level1")
                        g6.GetComponent<Text>().text = "";
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.A) && i != 0)
                            i -= 1;
                        else if (Input.GetKeyDown(KeyCode.D) && i != texts.Count - 1)
                            i += 1;
                        g6.GetComponent<Text>().text = texts[i];
                    }
                }
            }

            if (immunity)
                StartCoroutine(PlayerImmunity(2.0f, 0.2f));
        }

        if (score > 0 && Time.timeScale == 1 && !success)
            score--;

        if (g1)
            g1.GetComponent<Text>().text = healthPoints.ToString();

        if (healthPoints == 0)
            SceneManager.LoadSceneAsync("GameOver");
	}

    private IEnumerator PlayerImmunity(float time, float subTime)
    {
        while (time > 0)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(subTime);
            time -= subTime;
        }
        sr.enabled = true;
        immunity = false;
    }

    void ResetLevel(string s, int i)
    {
        SceneManager.LoadSceneAsync(s);
        locsLeft = i;
    }
}
