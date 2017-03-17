using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public bool movement;

    void Start ()
    {
        movement = true;
        moveSpeed = 20f;
        jumpSpeed = 20f;
    }

	void Update () {
        if (movement) {
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.W))
                transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime);
        }
    }

}
