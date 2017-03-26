using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOC : MonoBehaviour {

    public MainGame mg;
    public Player1 p;

    void OnTriggerEnter2D(Collider2D other)
    {
        mg.locsLeft--;
        p.moveSpeed = p.moveSpeed - 0.5f;
        p.jumpPower = p.jumpPower - 0.5f;
        Destroy(gameObject);
    }
}
