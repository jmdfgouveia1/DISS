using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingOtherComponents : MonoBehaviour {

    public GameObject otherGameObject;


    private AnotherScriptUOC anotherScript;
    private YetAnotherScriptUOC yetAnotherScript;
    private BoxCollider boxCol;


    void Awake()
    {
        anotherScript = GetComponent<AnotherScriptUOC>();
        yetAnotherScript = otherGameObject.GetComponent<YetAnotherScriptUOC>();
        boxCol = otherGameObject.GetComponent<BoxCollider>();
    }


    void Start()
    {
        boxCol.size = new Vector2(2, 2);
        Debug.Log("The player's score is " + anotherScript.playerScore);
        Debug.Log("The player has died " + yetAnotherScript.numberOfPlayerDeaths + " times");
    }
}
