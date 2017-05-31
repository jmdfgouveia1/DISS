using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LOC : MonoBehaviour {

    private GameObject g1, g2;
    private MainGame mg;

    void Start ()
    {
        g1 = GameObject.FindWithTag("Player");
        g2 = GameObject.FindWithTag("GameController");
        mg = g2.GetComponent<MainGame>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (g1 == other.gameObject)
        {
            if (SceneManager.GetActiveScene().name == "Level1")
                PlayerEffect(0.7f);
            else if (SceneManager.GetActiveScene().name == "Level2")
                PlayerEffect(0.6f);
            else if (SceneManager.GetActiveScene().name == "Level3")
                PlayerEffect(0.5f);
            else if (SceneManager.GetActiveScene().name == "Level4")
                PlayerEffect(0.4f);
            else if (SceneManager.GetActiveScene().name == "Level5")
                PlayerEffect(0.3f);
            mg.locCaught = true;
            mg.locsLeft--;
            Destroy(gameObject);
        }
    }

    void PlayerEffect(float f)
    {
        mg.moveSpeed -= f;
        mg.jumpPower -= f;
    }
}
