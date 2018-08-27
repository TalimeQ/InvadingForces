using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFX : MonoBehaviour {

  [SerializeField] private AudioSource deathFxSound;
    [SerializeField] private AudioClip deathAudio;
    [SerializeField] ParticleSystem deathhFxParticle;

    // Use this for initialization

    private void OnEnable()
    {
        OnDeath();
    }
    void  OnDeath()
    {
        deathFxSound.PlayOneShot(deathAudio);
        deathhFxParticle.Play();

        Invoke("DisableSystem", 0.5f);
    }
    void DisableSystem()
    {
        gameObject.SetActive(false);
    }
}
