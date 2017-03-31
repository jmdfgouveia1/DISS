using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOC : MonoBehaviour {

    public Player1 p;

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
            mg.locsLeft--;
            p.moveSpeed = p.moveSpeed - 0.5f;
            p.jumpPower = p.jumpPower - 0.5f;
            Destroy(gameObject);
        }
    }
}
