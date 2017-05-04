using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tome : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
        {
            if (SceneManager.GetActiveScene().name == "Tome1")
                SceneManager.LoadSceneAsync("Level1");
            if (SceneManager.GetActiveScene().name == "Tome2")
                SceneManager.LoadSceneAsync("Level2");
            if (SceneManager.GetActiveScene().name == "Tome3")
                SceneManager.LoadSceneAsync("Level3");
            if (SceneManager.GetActiveScene().name == "Tome4")
                SceneManager.LoadSceneAsync("Level4");
            if (SceneManager.GetActiveScene().name == "Tome5")
                SceneManager.LoadSceneAsync("Level5");
            if (SceneManager.GetActiveScene().name == "Tome6")
                SceneManager.LoadSceneAsync("Success");
        }
	}
}
