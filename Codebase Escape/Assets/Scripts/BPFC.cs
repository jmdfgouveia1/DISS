﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BPFC : MonoBehaviour {

    public Transform target;
    private float upbound, downbound, leftbound, rightbound;
    
    // Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            upbound = -1.5f;
            downbound = -7.8f;
            leftbound = -6.8f;
            rightbound = 7.8f;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            upbound = 4.5f;
            downbound = -14;
            leftbound = -16.9f;
            rightbound = 17.9f;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            upbound = 21;
            downbound = -30.5f;
            leftbound = -27.3f;
            rightbound = 28.3f;
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            upbound = 119;
            downbound = -30.6f;
            leftbound = -7.2f;
            rightbound = 8.3f;
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            upbound = 19.7f;
            downbound = -30.6f;
            leftbound = -27.4f;
            rightbound = 191.9f;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (target.position.y <= upbound && target.position.y >= downbound)
        {
            if (target.position.x <= rightbound && target.position.x >= leftbound)
                transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
        else
        {
            if (target.position.x <= rightbound && target.position.x >= leftbound)
                transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
	}
}
