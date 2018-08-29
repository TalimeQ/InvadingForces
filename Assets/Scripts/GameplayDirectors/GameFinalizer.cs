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

        showDeathMenu();
        int scoreToSave = scoreBoard.CurrentScore;
        for(int i = 1; i < 11; i++)
        {
            // porownuje od najwiekszego
           int comparedScore = PlayerPrefs.GetInt("Score" + i);
            // znalazlem pare
            if(scoreToSave > comparedScore)
            {
                // wepchnij wynik w pare
                PlayerPrefs.SetInt("Score" + i,scoreToSave);
                return;
                // reszta wynikow wzarsta o indeks
            }
        }
        
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
