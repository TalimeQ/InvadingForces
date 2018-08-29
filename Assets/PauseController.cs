using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {


    [SerializeField] PauseMenu menuPauzy;

    bool isPaused = false;

    private void Start()
    {
        if (!menuPauzy) FindObjectOfType<PauseMenu>();
      
    }
    private void Update()
    {
        if(!menuPauzy)
        {
            
       
            Debug.LogError("Błąd w PauseController, nie znaleziono skryptu kontrolujacego menu pauzy. Dodaj go  do odpowiedniego obiektu na scenie!");
            return;
        }
        if(Input.GetButtonDown("Cancel"))
        {
            onPauseInputRecieved();
        }
    }
    public void onPauseInputRecieved()
    {
        if(menuPauzy.gameObject.activeInHierarchy == true)
        {
            menuPauzy.UnPause();
            isPaused = false;
           
        }
        else
        {
            menuPauzy.Pause();
            isPaused = true;
            
        }
    }
}
