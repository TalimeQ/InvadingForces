using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour {

    [SerializeField] MenuManager mainMenu;
    [SerializeField] List<TextMeshProUGUI> scoreDisplay = new List<TextMeshProUGUI>();

    private void OnEnable()
    { 
        for (int i = 0;  i < 4 ; i ++)
        {
            scoreDisplay[i].text = "" + PlayerPrefs.GetInt("Score" + (i+1));
        }
    }
    // Use this for initialization
    public void OnReturnToMainMenu()
    {
        gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
}
