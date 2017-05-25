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
    public bool immunity, success, activePanel, pDocsActivated;
    //public bool upgrade1, upgrade2, upgrade3, upgrade4;
    public List<string> texts;

    private GameObject g1, g2, g3, g4, g5, g6;
    private Player1 p;
    private SpriteRenderer sr;
    private int i;
    private float leftPressTime, rightPressTime;
    private List<string> tomes;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

        score = 5000;
        immunity = false;
        success = false;
        activePanel = false;
        pDocsActivated = false;
        locsLeft = 5;
        moveSpeed = 20;
        resetMoveSpeed = moveSpeed;
        jumpPower = 20;
        resetJumpPower = jumpPower;
        healthPoints = 3;
        i = 0;
        texts = new List<string>();

        tomes = new List<string>();
        tomes.Add("Tome1");
        tomes.Add("Tome2");
        tomes.Add("Tome3");
        tomes.Add("Tome4");
        tomes.Add("Tome5");
        tomes.Add("Tome6");
    }
	
	// Update is called once per frame
	void Update () {
        g1 = GameObject.FindWithTag("HPCount");
        g2 = GameObject.FindWithTag("PausePanel");
        g3 = GameObject.FindWithTag("PausePanelText");
        g4 = GameObject.FindWithTag("Player");
        g5 = GameObject.FindWithTag("PDocsPanel");
        g6 = GameObject.FindWithTag("PDocsPanelText");

        if (checkIfNotTomes(SceneManager.GetActiveScene().name))
        {
            if (Input.GetButtonDown("Submit"))
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

            if (Input.GetButtonDown("Fire3") && Time.timeScale == 0)
            {
                if (SceneManager.GetActiveScene().name == "Level1")
                    ResetLevel("Level1", 5);
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
                    g6.GetComponent<Text>().fontSize = 32;

                    if (Input.GetButtonDown("Fire2") && Time.timeScale == 1 && !activePanel)
                    {
                        if (!g5.GetComponent<Image>().enabled)
                        {
                            g5.GetComponent<Image>().enabled = true;
                            g6.GetComponent<Text>().enabled = true;
                            pDocsActivated = true;
                            p.movement = false;
                        }
                        else
                        {
                            g5.GetComponent<Image>().enabled = false;
                            g6.GetComponent<Text>().enabled = false;
                            pDocsActivated = false;
                            p.movement = true;
                        }
                    }

                    if (g5.GetComponent<Image>().enabled)
                    {
                        if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") < 0 && i != 0)
                        {
                            i -= 1;
                            leftPressTime = Time.time;
                        }
                        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
                        {
                            if (Time.time - leftPressTime > 0.5 && i != 0)
                                i -= 1;
                        }
                        if (Input.GetButtonDown("Horizontal") && Input.GetAxis("Horizontal") > 0 && i != texts.Count - 1)
                        {
                            i += 1;
                            rightPressTime = Time.time;
                        }
                        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
                        {
                            if (Time.time - rightPressTime > 0.5 && i != texts.Count - 1)
                                i += 1;
                        }
                                
                        g6.GetComponent<Text>().text = texts[i];
                    }
                }

                if (immunity)
                    StartCoroutine(PlayerImmunity(2.0f, 0.2f));
            }

            if (score > 0 && Time.timeScale == 1 && !success && checkIfNotTomes(SceneManager.GetActiveScene().name))
                score--;
        }

        if (g1)
            g1.GetComponent<Text>().text = healthPoints.ToString();

        if (healthPoints == 0 && SceneManager.GetActiveScene().name != "GameOver")
            SceneManager.LoadSceneAsync("GameOver");
	}

    private IEnumerator PlayerImmunity(float time, float subTime)
    {
        while (time > 0)
        {
            if (g4)
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

    private bool checkIfNotTomes(string s)
    {
        for (int j = 0; j<tomes.Count-1; j++)
        {
            if (s == tomes[j])
                return false;
        }

        return true;
    }
}
