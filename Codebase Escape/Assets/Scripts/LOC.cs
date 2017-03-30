using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOC : MonoBehaviour {

    public MainGame mg;
    public Player1 p;

    private GameObject g;

    void Start ()
    {
        g = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (g == other.gameObject)
        {
            mg.locsLeft--;
            p.moveSpeed = p.moveSpeed - 0.5f;
            p.jumpPower = p.jumpPower - 0.5f;
            Destroy(gameObject);
        }
    }
}
