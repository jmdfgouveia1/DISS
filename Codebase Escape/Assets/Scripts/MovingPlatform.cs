using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public float upbound, leftbound, rightbound, downbound;
    public bool horizontalMovement, verticalMovement, moveLeft, moveUp;
	
	// Update is called once per frame
	void Update () {
        if (horizontalMovement)
        {
            if (moveLeft)
                transform.Translate(Vector2.left * 5 * Time.deltaTime);
            else
                transform.Translate(Vector2.right * 5 * Time.deltaTime);

            if (transform.position.x >= rightbound)
                moveLeft = true;
            else if (transform.position.x <= leftbound)
                moveLeft = false;
        }   
        
        if (verticalMovement)
        {
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
}
