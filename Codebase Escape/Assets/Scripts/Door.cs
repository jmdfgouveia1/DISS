using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public Sprite s1, s2;
    public Player1 p;

    private MainGame mg;
    private DOC doc1, doc2;
    private GameObject g1, g2, g3, g4, g5, g6;
    private bool onTrigger;

    void Start()
    {
        onTrigger = false;
        g1 = GameObject.FindWithTag("DoorText");
        g2 = GameObject.FindWithTag("DoorPanel");
        g3 = GameObject.FindWithTag("DoorPanelText");
        g4 = GameObject.FindWithTag("GameController");
        g5 = GameObject.FindWithTag("Doc1");
        g6 = GameObject.FindWithTag("Doc2");
        mg = g4.GetComponent<MainGame>();
        doc1 = g5.GetComponent<DOC>();
        if (g6)
            doc2 = g6.GetComponent<DOC>();
        g2.GetComponent<Image>().enabled = false;
        g3.GetComponent<Text>().enabled = false;
        g3.GetComponent<Text>().fontSize = 42;
    }

    // Update is called once per frame
    void Update () {
        if (mg.locsLeft > 0)
            GetComponent<SpriteRenderer>().sprite = s1;
        else
            GetComponent<SpriteRenderer>().sprite = s2;

       if (!g2.GetComponent<Image>().enabled)
       {
            if (Input.GetKeyDown(KeyCode.Return) && onTrigger && Time.timeScale == 1)
            {
                g2.GetComponent<Image>().enabled = true;
                g3.GetComponent<Text>().enabled = true;
                mg.activePanel = true;
                p.movement = false;
            }
       }
       else
       {
            if (SceneManager.GetActiveScene().name == "Level1")
            {
                if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Return)) && Time.timeScale == 1)
                {
                    g2.GetComponent<Image>().enabled = false;
                    g3.GetComponent<Text>().enabled = false;
                    PanelExit();
                }
                else if (Input.GetKeyDown(KeyCode.S))
                {
                    PanelExit();
                    mg.moveSpeed += 2.5f;
                    mg.jumpPower += 2.5f;
                    mg.healthPoints += 2;
                    mg.locsLeft = 6;
                    mg.score += 5000;
                    ResetAbilities();
                    mg.texts.Add(doc1.text1);
                    SceneManager.LoadSceneAsync("Level2");
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level2")
            {
                if ((Input.GetKeyDown(KeyCode.U) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Return)) && Time.timeScale == 1)
                {
                    g2.GetComponent<Image>().enabled = false;
                    g3.GetComponent<Text>().enabled = false;
                    PanelExit();
                }
                else if (Input.GetKeyDown(KeyCode.O))
                {
                    PanelExit();
                    mg.moveSpeed += 10;
                    mg.locsLeft = 7;
                    mg.score += 10000;
                    ResetAbilities();
                    mg.texts.Add(doc1.text1);
                    SceneManager.LoadSceneAsync("Level3");
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level3")
            {
                if ((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Return)) && Time.timeScale == 1)
                {
                    g2.GetComponent<Image>().enabled = false;
                    g3.GetComponent<Text>().enabled = false;
                    PanelExit();
                }
                else if (Input.GetKeyDown(KeyCode.L))
                {
                    PanelExit();
                    mg.jumpPower += 10;
                    mg.locsLeft = 8;
                    mg.score += 15000;
                    ResetAbilities();
                    mg.texts.Add(doc1.text1);
                    mg.texts.Add(doc2.text2);
                    SceneManager.LoadSceneAsync("Level4");
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level4")
            {
                if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return)) && Time.timeScale == 1)
                {
                    g2.GetComponent<Image>().enabled = false;
                    g3.GetComponent<Text>().enabled = false;
                    PanelExit();
                }
                else if (Input.GetKeyDown(KeyCode.I))
                {
                    PanelExit();
                    mg.healthPoints += 10;
                    mg.score += 20000;
                    mg.locsLeft = 1;
                    ResetAbilities();
                    mg.texts.Add(doc1.text1);
                    mg.texts.Add(doc2.text2);
                    SceneManager.LoadSceneAsync("Level5");
                    Application.Quit();
                }
            }
            else if (SceneManager.GetActiveScene().name == "Level5")
            {
                if ((Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Return)) && Time.timeScale == 1)
                {
                    g2.GetComponent<Image>().enabled = false;
                    g3.GetComponent<Text>().enabled = false;
                    PanelExit();
                }
                else if (Input.GetKeyDown(KeyCode.D))
                {
                    PanelExit();
                    SceneManager.LoadSceneAsync("Success");
                }
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (mg.locsLeft == 0)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
                g1.GetComponent<Text>().text = "Press action button to proceed.";
            onTrigger = true;
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "Level1")
                g1.GetComponent<Text>().text = "Get all LOCs to open the door.";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onTrigger = false;
        g1.GetComponent<Text>().text = "";
    }

    void PanelExit()
    {
        p.movement = true;
        mg.activePanel = false;
    }

    void ResetAbilities()
    {
        mg.resetMoveSpeed = mg.moveSpeed;
        mg.resetJumpPower = mg.jumpPower;
        mg.resetScore = mg.score;
        mg.resetHPs = mg.healthPoints;
    }
}
