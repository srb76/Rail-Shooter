using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject leftLaser, rightLaser;

    void OnTriggerEnter(Collider other)
    {
        print("Player triggered something!");
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        //disable controls
        SendMessage("Death");
        //play explosion and disable laser particle systems
        leftLaser.SetActive(false); //should not be necessary later, use disable controls boolean in input
        rightLaser.SetActive(false);
        explosion.SetActive(true);

        //load new level
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
