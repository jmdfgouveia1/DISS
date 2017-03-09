using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    void Start()
    {
        Player myPlayer = new Player();

        //Properties can be used just like variables
        myPlayer.Experience = 5;
        int x = myPlayer.Experience;
        myPlayer.Level = 5;
        int y = myPlayer.Level;
        myPlayer.Health = 5;
        int z = myPlayer.Health;
        print(x + y + z);
    }
}
