using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    public MainGame mg;
    public float moveSpeed;
    public float jumpSpeed;

    void Start ()
    {
        moveSpeed = 15f;
        jumpSpeed = 15f;
    }

	void Update () {
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector2.up * jumpSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        mg.locsLeft--;
        moveSpeed = moveSpeed - 0.5f;
        jumpSpeed = jumpSpeed - 0.5f;
        Destroy(other.gameObject);
    }
}
