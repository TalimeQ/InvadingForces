using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Invading.Global;

public  class PauseMenu : MonoBehaviour {

    [SerializeField] PlayerController playerController;
    [SerializeField] GameFinalizer gameFinalizer;
    

    private void Start()
    {
        if (!playerController) playerController = FindObjectOfType<PlayerController>();
        if (!gameFinalizer) gameFinalizer = FindObjectOfType<GameFinalizer>();

      
    }
    public  void Pause()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
        playerController.toggleInputConsumption(false);
        
        
    }
    public  void UnPause()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        playerController.toggleInputConsumption(true);
    }
    public void ReturnToMenu()
    {
        gameFinalizer.SaveScore();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    }
}
