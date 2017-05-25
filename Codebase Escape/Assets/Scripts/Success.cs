using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Success : MonoBehaviour {

    private GameObject g1;
    private MainGame mg;

	// Use this for initialization
	void Start () {
        g1 = GameObject.FindWithTag("GameController");
        mg = g1.GetComponent<MainGame>();
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "CONGRATULATIONS!\n\nYou escaped the code base with a score of " + mg.score + ".\n\nPress the action button to play the game again or the escape button to return to the main menu.";

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
