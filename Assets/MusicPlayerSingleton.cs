using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerSingleton : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        int numberOfCopies = FindObjectsOfType<MusicPlayerSingleton>().Length;

        //prevent duplicates
        if (numberOfCopies < 2)
            DontDestroyOnLoad(gameObject);
        else
            Destroy(gameObject);
    }
}
