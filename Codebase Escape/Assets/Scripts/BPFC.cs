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
            upbound = -1.7f;
            downbound = -7.6f;
            leftbound = -6.9f;
            rightbound = 7.9f;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            upbound = 4.3f;
            downbound = -13.8f;
            leftbound = -16.9f;
            rightbound = 17.9f;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            upbound = 20.75f;
            downbound = -30.3f;
            leftbound = -27.1f;
            rightbound = 28.2f;
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            upbound = 118.8f;
            downbound = -30.3f;
            leftbound = -7.1f;
            rightbound = 8.2f;
        }
        else if (SceneManager.GetActiveScene().name == "Level5")
        {
            upbound = 18.8f;
            downbound = -30.3f;
            leftbound = -27.4f;
            rightbound = 191.7f;
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
