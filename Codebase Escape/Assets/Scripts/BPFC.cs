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
            upbound = 0.75f;
            downbound = -10;
            leftbound = -11.35f;
            rightbound = 12.35f;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            upbound = 6.7f;
            downbound = -16.25f;
            leftbound = -21.35f;
            rightbound = 22.3f;
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            upbound = 23.25f;
            downbound = -32.75f;
            leftbound = -31.5f;
            rightbound = 32.65f;
        }
        else if (SceneManager.GetActiveScene().name == "Level4")
        {
            upbound = 121.25f;
            downbound = -32.75f;
            leftbound = -11.55f;
            rightbound = 12.65f;
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
