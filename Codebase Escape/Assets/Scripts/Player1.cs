using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    public bool movement;

    private Rigidbody2D rb;
    private GameObject g;
    private MainGame mg;

    void Start ()
    {
        movement = true;
        g = GameObject.FindWithTag("GameController");
        mg = g.GetComponent<MainGame>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
    }

	void Update () {

        if (movement) {
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector2.left * mg.moveSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector2.right * mg.moveSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.W))
                rb.AddForce(Vector2.up * mg.jumpPower * 50);
            if (Input.GetKeyUp(KeyCode.W))
                rb.AddForce(Vector2.down * mg.jumpPower * 50);
        }
    }

}
