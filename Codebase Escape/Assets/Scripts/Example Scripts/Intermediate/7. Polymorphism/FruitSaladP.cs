using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSaladP : MonoBehaviour {

    void Start()
    {
        //Notice here how the variable "myFruit" is of type
        //Fruit but is being assigned a reference to an Apple. This
        //works because of Polymorphism. Since an Apple is a Fruit,
        //this works just fine. While the Apple reference is stored
        //in a Fruit variable, it can only be used like a Fruit
        FruitP myFruit = new AppleP();

        myFruit.SayHello();
        myFruit.Chop();

        //This is called downcasting. The variable "myFruit" which is 
        //of type Fruit, actually contains a reference to an Apple. Therefore,
        //it can safely be turned back into an Apple variable. This allows
        //it to be used like an Apple, where before it could only be used
        //like a Fruit.
        AppleP myApple = (AppleP)myFruit;

        myApple.SayHello();
        myApple.Chop();
    }
}
