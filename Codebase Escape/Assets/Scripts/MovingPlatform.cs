using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public float upbound, downbound;
    public bool moveUp;
	
	// Update is called once per frame
	void Update () { 
        if (moveUp)
            transform.Translate(Vector2.up * 5 * Time.deltaTime);
        else
            transform.Translate(Vector2.down * 5 * Time.deltaTime);

        if (transform.position.y >= upbound)
            moveUp = false;
        else if (transform.position.y <= downbound)
            moveUp = true;
    }
}
