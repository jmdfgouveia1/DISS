using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeOtherClassG : MonoBehaviour {

    void Start()
    {
        SomeClassG myClass = new SomeClassG();

        //In order to use this method you must
        //tell the method what type to replace
        //'T' with.
        print(myClass.GenericMethod<int>(5));
    }
}
