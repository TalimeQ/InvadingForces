using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invading.Global { 
public class MusicPlayer : MonoBehaviour, IBossListener , IMainMenuMusicListener{

    [SerializeField] AudioClip MenuMusic;
    [SerializeField] AudioClip StandardMusic;
    [SerializeField] AudioClip BossMusic;
    [SerializeField] AudioSource musicPlayer;

        public void OnBossDeath()
        {
            musicPlayer.clip = StandardMusic;
            musicPlayer.Play();
        }

        public void OnBossEnter(bool wavesTurned)
        {
            musicPlayer.clip = BossMusic;
            musicPlayer.Play();
        }

        public void OnMainMenuEnter()
        {
            musicPlayer.clip = MenuMusic;
            musicPlayer.Play();
        }

        public void OnMainMenuLeave()
        {
            musicPlayer.clip = StandardMusic;
            musicPlayer.Play();
        }

        void Start ()
        {
        DontDestroyOnLoad(this.gameObject);
	    }
	
	
	void Update () {
		
	}
}
}