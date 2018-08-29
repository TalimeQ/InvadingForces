using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinalizer : MonoBehaviour, IPlayerDeathListener
{
    [SerializeField] DeathMenu deathMenu;

    void Start()
    {
        // obiekt jest jeden wiec zabezpieczamy przed nierozgarnietym designerem :)
        //deathMenu = FindObjectOfType<DeathMenu>();
    }

    void IPlayerDeathListener.OnPlayerDeath()
    {
        if(!deathMenu)
        {
            Debug.Log("Brak referencji do menu smierci, dodaj ja kocie :*");
            return;
        }
        deathMenu.gameObject.SetActive(true);
        Debug.Log("Player is ded.");
    }

    
}
