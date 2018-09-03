using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {



    public void Retry()
    {
        SceneManager.LoadScene(1);
        this.gameObject.SetActive(false);
       
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
}
