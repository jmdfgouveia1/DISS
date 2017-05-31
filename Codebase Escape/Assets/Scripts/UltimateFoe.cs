using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateFoe : MonoBehaviour {

    public float bound;

    private GameObject g1, g2;
    private MainGame mg;

    // Use this for initialization
    void Start () {
        GetComponent<PolygonCollider2D>().isTrigger = false;

        g1 = GameObject.FindWithTag("GameController");
        g2 = GameObject.FindWithTag("Player");
        mg = g1.GetComponent<MainGame>();
	}
	
	// Update is called once per frame
	void Update () {
		if (mg.locsLeft == 0)
        {
            if (transform.position.x < bound)
                transform.Translate(Vector2.right * 4 * Time.deltaTime);

            if (mg.immunity)
                GetComponent<PolygonCollider2D>().isTrigger = false;
            else
                GetComponent<PolygonCollider2D>().isTrigger = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (g2 == other.gameObject)
        {
            mg.moveSpeed -= 2.5f;
            mg.jumpPower -= 2.5f;
            mg.healthPoints -= 5;
            GetComponent<AudioSource>().Play();
            mg.immunity = true;
        }
    }
}
