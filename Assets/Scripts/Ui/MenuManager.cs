using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Invading.Global;

public class MenuManager : MonoBehaviour {

    [SerializeField] HighScores highScoresDisplay;
    IMainMenuMusicListener mainMenuMusicListener;

    private void Start()
    {
        mainMenuMusicListener = FindObjectOfType<MusicPlayer>();
        mainMenuMusicListener.OnMainMenuEnter();
    }

    public void OnStartClicked()
    {
        mainMenuMusicListener.OnMainMenuLeave();
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
