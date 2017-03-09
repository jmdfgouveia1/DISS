using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : EnemyMH {

    //This hides the EnemyMH version.
    new public void Yell()
    {
        Debug.Log("Orc version of the Yell() method");
    }
}
