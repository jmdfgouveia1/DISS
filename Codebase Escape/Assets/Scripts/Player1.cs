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
            if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
                transform.Translate(Vector2.left * mg.moveSpeed * Time.deltaTime);
            if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0)
                transform.Translate(Vector2.right * mg.moveSpeed * Time.deltaTime);
            if ((Input.GetButtonDown("Vertical") && Input.GetAxis("Vertical") > 0) || Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up * mg.jumpPower * 50);
                GetComponent<AudioSource>().Play();
            }
            if ((Input.GetButtonUp("Vertical") && Input.GetAxis("Vertical") > 0) || Input.GetButtonUp("Jump"))
                rb.AddForce(Vector2.down * mg.jumpPower * 50);
        }
    }

}
