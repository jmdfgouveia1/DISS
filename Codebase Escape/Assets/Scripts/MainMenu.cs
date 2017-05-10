﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
            SceneManager.LoadSceneAsync("Tome1");
        else if (Input.GetButtonDown("Cancel"))
            Application.Quit();
	}
}
