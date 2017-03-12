using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingDeltaTimes : MonoBehaviour {

    public float speed = 8f;
    public float countdown = 3.0f;

    private Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.enabled = false;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
            myLight.enabled = true;

        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
    }
}
