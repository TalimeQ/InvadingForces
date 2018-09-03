using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Invading.Global;

public  class PauseMenu : MonoBehaviour {

    [SerializeField] PlayerController playerController;
 
    

    private void Start()
    {
        if (!playerController) FindObjectOfType<PlayerController>();
      
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
   
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    }
}
