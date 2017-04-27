using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Foe : MonoBehaviour {

    public bool moveLeft;
    public float leftbound, rightbound;

    private GameObject g1, g2;
    private MainGame mg;

	// Use this for initialization
	void Start () {
        GetComponent<PolygonCollider2D>().isTrigger = true;

        g1 = GameObject.FindWithTag("GameController");
        g2 = GameObject.FindWithTag("Player");
        mg = g1.GetComponent<MainGame>();
	}
	
	// Update is called once per frame
	void Update () {
        if (moveLeft)
            transform.Translate(Vector2.left * 2 * Time.deltaTime);
        else 
            transform.Translate(Vector2.right * 2 * Time.deltaTime);

        if (transform.position.x >= rightbound)
        {
            if (SceneManager.GetActiveScene().name == "Level5" &&
                (gameObject.tag == "DuplicateFoe2" || gameObject.tag == "DamageFoe"))
                Destroy(gameObject);
            else
                moveLeft = true;
        } 
        else if (transform.position.x <= leftbound)
        {
            if (SceneManager.GetActiveScene().name == "Level5" &&
                (gameObject.tag == "DuplicateFoe1" || gameObject.tag == "DuplicateFoe3"))
                Destroy(gameObject);
            else
                moveLeft = false;
        }
        
        if (mg.immunity)
            GetComponent<PolygonCollider2D>().isTrigger = false;
        else
            GetComponent<PolygonCollider2D>().isTrigger = true;
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
            else if (gameObject.tag == "DamageFoe")
                mg.healthPoints--;

            mg.immunity = true;
        }
    }
}
