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
            leftbound = -11.25f;
            rightbound = 12.15f;
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            upbound = 6.7f;
            downbound = -16.25f;
            leftbound = -21.25f;
            rightbound = 22.25f;
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
