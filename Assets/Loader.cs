using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    Text text;
    
    void Start()
    {
        //Get text object
        text = GameObject.FindObjectOfType<Text>();
    }

    void Update()
    {
        if (Input.anyKey)
        {
            StartCoroutine(LoadLevel());
            text.text = "Loading...";
        }
    }

    IEnumerator LoadLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level 1");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        
    }
}
