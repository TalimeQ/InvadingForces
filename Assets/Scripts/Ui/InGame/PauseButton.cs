using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour  {

   
    IPauseListener pauseListener;
    PlayerController playerController;
    private void Start()
    {
        pauseListener = FindObjectOfType<PauseController>();
        playerController = FindObjectOfType<PlayerController>();
       
    }
    public void onPauseButtonClicked()
    {
        pauseListener.onPauseButtonClicked();
    }
    public void OnPointerEnter()
    {
        playerController.toggleClickConsumption(false);
    }
    public void OnPointerLeave()
    {
        playerController.toggleClickConsumption(true);
    }

}
