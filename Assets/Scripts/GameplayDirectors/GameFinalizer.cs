using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinalizer : MonoBehaviour, IPlayerDeathListener
{
    [SerializeField] DeathMenu deathMenu;
    [SerializeField] ScoreBoard scoreBoard;

    void Start()
    {
        // obiekt jest jeden wiec zabezpieczamy przed nierozgarnietym designerem :)
        //deathMenu = FindObjectOfType<DeathMenu>();
    }

    void IPlayerDeathListener.OnPlayerDeath()
    {
        SaveScore();
        showDeathMenu();
    }

    public void SaveScore()
    {
        Scores scores = JsonUtility.FromJson<Scores>(PlayerPrefs.GetString("Scores"));

        if (scores == null || scores.highScores.Count == 0)
        {
            scores = new Scores();
            scores.Init();
        }
        int scoreToSave = scoreBoard.CurrentScore;
        scores.AddScore(scoreToSave);
        var savedScores = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("Scores", savedScores);
    }

    void showDeathMenu()
    {
        if (!deathMenu)
        {
            Debug.Log("Brak referencji do menu smierci, dodaj ja kocie :*");
            return;
        }

        deathMenu.gameObject.SetActive(true);

    }
    

    void injectIfHighScore(int scoreToSave, List<int> playerScores)
    {
        // check for highscores and swap if it occured
 
    }
}
