using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreBoard : MonoBehaviour {

    [SerializeField]
    TextMeshProUGUI scoreText;
    int currentScore = 0;
	// Use this for initialization
	void Start () {
        scoreText.SetText("Score: 0");
	}
	
	// Update is called once per frame

    public  void addScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.SetText("Score: " + currentScore);
    }
}
