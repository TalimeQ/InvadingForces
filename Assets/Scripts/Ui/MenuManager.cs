using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField] HighScores highScoresDisplay;

    public void OnStartClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitClicked()
    {
        Debug.Log("Quit Clicked!");
        Application.Quit();
    }
    public void OnHighScoresClicked()
    {
        this.gameObject.SetActive(false);
        highScoresDisplay.gameObject.SetActive(true);
    }
}
