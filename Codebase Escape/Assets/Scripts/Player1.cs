using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    public float moveSpeed;
    public float jumpPower;
    public bool movement;

    private Rigidbody2D rb;
    private RaycastHit2D hit;

    void Start ()
    {
        movement = true;
        moveSpeed = 20f;
        jumpPower = 20f;

        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1;
    }

	void Update () {

        hit = Physics2D.Raycast(transform.position, -Vector2.up, 0.1f);

        if (movement) {
            if (Input.GetKey(KeyCode.A))
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.D))
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.W) && hit.collider != null)
                rb.AddForce(Vector2.up * jumpPower * 50);
            if (Input.GetKeyUp(KeyCode.W))
                rb.AddForce(Vector2.down * jumpPower * 25);
        }
    }

}
