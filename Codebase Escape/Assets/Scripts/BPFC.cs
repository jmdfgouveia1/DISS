using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPFC : MonoBehaviour {

    public Transform target;
    
    // Use this for initialization
	void Start () {
        transform.position = new Vector3(0, -10, -118);
	}
	
	// Update is called once per frame
	void Update () {
        if (target.position.y <= 0.75 && target.position.y >= -10)
        {
            if (target.position.x <= 12.25 && target.position.x >= -11.25)
                transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
            else
                transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z);
        }
        else
        {
            if (target.position.x <= 12.25 && target.position.x >= -11.25)
                transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        }
	}
}
