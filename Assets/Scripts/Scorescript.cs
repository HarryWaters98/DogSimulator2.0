using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorescript : MonoBehaviour {

	public static int ScoreValue = 0;
    Text Score;

    public void Start()
    {
        Score = GetComponent<Text>();
    }

    public void Update()
    {
        Score.text = "Bones Collected : " + ScoreValue;
    }
}
