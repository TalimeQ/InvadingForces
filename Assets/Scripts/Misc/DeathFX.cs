using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFX : MonoBehaviour {

  [SerializeField] private AudioSource deathAudioSource;
    [SerializeField] private AudioClip deathAudioClip;
    [SerializeField] ParticleSystem deathhFxParticle;

    // Use this for initialization

    private void OnEnable()
    {
        OnDeath();
    }
    void  OnDeath()
    {
        deathAudioSource.PlayOneShot(deathAudioClip);
        deathhFxParticle.Play();

        Invoke("DisableSystem", 0.5f);
    }
    void DisableSystem()
    {
        gameObject.SetActive(false);
    }
}
