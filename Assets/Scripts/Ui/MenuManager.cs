﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {


    public void OnStartClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void OnQuitClicked()
    {
        Debug.Log("Quit Clicked!");
        Application.Quit();
    }
}
