﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void addScore(int scorePerHit)
    {
        score += scorePerHit;
        //update text
        scoreText.text = score.ToString();
    }
}
