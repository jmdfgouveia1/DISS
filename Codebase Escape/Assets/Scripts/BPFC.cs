using System.Collections;
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
            upbound = 2.4f;
            downbound = -8.4f;
            leftbound = -6.8f;
            rightbound = 7.8f;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            upbound = 1.4f;
            downbound = -15.4f;
            leftbound = -17.5f;
            rightbound = 18.5f;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            upbound = 21.4f;
            downbound = -30.9f;
            leftbound = -27.6f;
            rightbound = 28.8f;
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            upbound = 130.4f;
            downbound = -30.9f;
            leftbound = -7.7f;
            rightbound = 8.7f;
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            upbound = 21.9f;
            downbound = -30.9f;
            leftbound = -27.9f;
            rightbound = 192.3f;
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
