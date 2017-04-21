using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TernaryOperator : MonoBehaviour {

    private int health;
    private string message;

    void Start()
    {
        health = 10;
    }

    void Update()
    {
        //This is an example Ternary Operation that chooses a message based
        //on the variable "health".
        message = health > 0 ? "Player is Alive" : "Player is Dead";
        print(message);

        health--;
    }
}
