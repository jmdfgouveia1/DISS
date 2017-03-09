using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMH : Humanoid {

    //This hides the Humanoid version.
    new public void Yell()
    {
        Debug.Log("EnemyMH version of the Yell() method");
    }
}
