﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorescript : MonoBehaviour {

	public static int ScoreValue = 0;
    Text Score;

    public GameObject CompleteLevelUI;

    public void Start()
    {
        Score = GetComponent<Text>();
    }

    public void Update()
    {
        Score.text = "Bones Collected : " + ScoreValue;

        
    }

    public void EndGame()
    {
        bool endgame = false;

        if (ScoreValue == 25)
        {
            CompleteLevelUI.SetActive(true);
        }

    }


}
