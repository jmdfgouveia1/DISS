using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeMovement : MonoBehaviour {

    public bool moveLeft;
    public float leftbound, rightbound;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (moveLeft)
            transform.Translate(Vector2.left * 2 * Time.deltaTime);
        else
            transform.Translate(Vector2.right * 2 * Time.deltaTime);

        if (transform.position.x >= rightbound)
            moveLeft = true;
        else if (transform.position.x <= leftbound)
            moveLeft = false;
    }
}
