using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeSpawner : MonoBehaviour {

    public GameObject g;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnFoe", 4, 4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnFoe()
    {
        GameObject instance = Instantiate(g, transform.position, Quaternion.identity);
        g = instance;
    }
}
