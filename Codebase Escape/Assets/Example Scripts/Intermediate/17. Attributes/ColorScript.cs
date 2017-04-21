using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ColorScript : MonoBehaviour {

    void Start()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.red;
        Debug.Log("Edit mode!");
    }
}
