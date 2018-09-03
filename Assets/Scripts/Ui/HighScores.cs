using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScores : MonoBehaviour {

    [SerializeField] MenuManager mainMenu;
    [SerializeField] List<TextMeshProUGUI> scoreDisplay = new List<TextMeshProUGUI>();

    private void OnEnable()
    {
        Scores scores = JsonUtility.FromJson<Scores>(PlayerPrefs.GetString("Scores"));
        if (scores == null)
        {
           
            return;
        }

        else
        {
           
            for (int i = 0; i < 4; i++)
            {
                scoreDisplay[i].SetText("" + scores.ReturnScore(i));
 
            }
        }
    }
    // Use this for initialization
    public void OnReturnToMainMenu()
    {
        gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
}
