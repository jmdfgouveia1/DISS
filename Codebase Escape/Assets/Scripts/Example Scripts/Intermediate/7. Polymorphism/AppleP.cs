﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleP : FruitP {

    public AppleP()
    {
        Debug.Log("1st Apple Constructor Called");
    }

    //Apple has its own version of Chop() and SayHello(). 
    //When running the scripts, notice when Fruit's version
    //of these methods are called and when Apple's version
    //of these methods are called.
    //In this example, the "new" keyword is used to supress
    //warnings from Unity while not overriding the methods
    //in the Apple class.
    public new void Chop()
    {
        Debug.Log("The apple has been chopped.");
    }

    public new void SayHello()
    {
        Debug.Log("Hello, I am an apple.");
    }
}
