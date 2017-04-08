using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOC : MonoBehaviour {

    private GameObject g1, g2;
    private MainGame mg;

    void Start ()
    {
        g1 = GameObject.FindWithTag("Player");
        g2 = GameObject.FindWithTag("GameController");
        mg = g2.GetComponent<MainGame>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (g1 == other.gameObject)
        {
            mg.moveSpeed -= 0.5f;
            mg.jumpPower -= 0.5f;
            mg.locsLeft--;
            Destroy(gameObject);
        }
    }
}
