using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foe : MonoBehaviour {

    public bool movement, moveLeft;
    public float leftbound, rightbound;

    private GameObject g1, g2;
    private MainGame mg;
    private SpriteRenderer sr;
    private bool immunity;

	// Use this for initialization
	void Start () {
        GetComponent<PolygonCollider2D>().isTrigger = true;

        g1 = GameObject.FindWithTag("GameController");
        g2 = GameObject.FindWithTag("Player");
        mg = g1.GetComponent<MainGame>();
        sr = g2.GetComponent<SpriteRenderer>();
        movement = true;
        immunity = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (movement)
        {
            if (moveLeft)
                transform.Translate(Vector2.left * 2 * Time.deltaTime);
            else
                transform.Translate(Vector2.right * 2 * Time.deltaTime);

            if (transform.position.x >= rightbound)
                moveLeft = true;
            else if (transform.position.x <= leftbound)
                moveLeft = false;
        }
        
        if (immunity == true)
        {
            GetComponent<PolygonCollider2D>().isTrigger = false;
            sr.enabled = !sr.enabled;
        }
        else
        {
            sr.enabled = true;
            GetComponent<PolygonCollider2D>().isTrigger = true;
        }   
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (g2 == other.gameObject)
        {
            if (gameObject.tag == "DuplicateFoe1")
                mg.moveSpeed -= 0.5f;
            else if (gameObject.tag == "DuplicateFoe2")
                mg.jumpPower -= 0.5f;
            else if (gameObject.tag == "DuplicateFoe3")
            {
                mg.moveSpeed -= 0.5f;
                mg.jumpPower -= 0.5f;
            }

            StartCoroutine(PlayerImmunity(2.0f));
        }
    }

    private IEnumerator PlayerImmunity(float time)
    {
        immunity = true;
        yield return new WaitForSeconds(time);
        immunity = false;
    }
}
