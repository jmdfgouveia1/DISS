﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeRepeating : MonoBehaviour {

    public GameObject target;


    void Start()
    {
        InvokeRepeating("SpawnObject", 2, 1);
    }

    void SpawnObject()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float y = Random.Range(-2.0f, 2.0f);
        Instantiate(target, new Vector2(x, y), Quaternion.identity);
    }
}