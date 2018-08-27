using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  Holds  player shooting components
/// </summary>
public class PlayerCombat : MonoBehaviour {

    [Header("Shooting")]
    [Tooltip("Time between cannon reload")]
    [SerializeField] float reloadTime = 1.0f;
    private float NextFireTime = 0;
    bool isLaserActive;
    private int laserAmmo = 30;


    [Header("Hitpoints and death")]
    int hitPoints = 3;
    [SerializeField]
    int hitPointCap = 3;

    [Header("Effects")]
    [SerializeField]
    AudioSource playerAudioSource;
    [SerializeField]
    GameObject deathEffect;
    [SerializeField]
    AudioClip laserAudio;
    [SerializeField]
    AudioClip standShotAudio;

    private void Start()
    {
        hitPoints = hitPointCap;
        playerAudioSource = gameObject.GetComponent<AudioSource>();
    }
    private void ProcessWeaponSwap()
    {
        isLaserActive = !isLaserActive;
        print("Laser Active!");

    }
    private void ProcessShooting()
    {

        print("FIRING");
        if (NextFireTime <= Time.time)
        {
            if (!isLaserActive)
            { 
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Bullet");
                if (bullet != null)
                {
                    PlayAudioClip(standShotAudio);
                    NextFireTime = Time.time + reloadTime;
                    bullet.transform.rotation = Quaternion.identity;
                    bullet.transform.position = gameObject.transform.position + Vector3.up;
                    bullet.SetActive(true);
                }
            }
            else if(laserAmmo > 0)
            {
                laserAmmo--;
                GameObject laserProj = ObjectPooler.SharedInstance.GetPooledObject("LaserProj");
                if (laserProj)
                {
                    PlayAudioClip(laserAudio);
                    NextFireTime = Time.time + reloadTime / 5;
                    laserProj.transform.rotation = Quaternion.identity;
                    laserProj.transform.position = gameObject.transform.position + Vector3.up;
                    laserProj.SetActive(true);
                }
                else Debug.LogWarning("Brak tagu LaserProj");
            }

        }
        
 

    }

    private void PlayAudioClip(AudioClip audioToPlay)
    {
        if(!playerAudioSource)
        {
            Debug.LogWarning("Skrypt combatu gracza probowal zagrac dzwiek na: " + gameObject.name + ". Niestety obiektowi bramuje audio source. Napraw to prosze ;)");
            return;
        }
        if(!audioToPlay)
        {
            Debug.LogWarning(" Skrypt combatu gracza probowal zagrac dzwiek na: " + gameObject.name + ".Niestety obiektowi brakuje jednego z audio clipow.Napraw to prosze ;)");
            return;
        }
        playerAudioSource.PlayOneShot(audioToPlay);
    }

    private void ProcessHit(int damage)
    {
        print("Player :: I've been hit for " + damage + "damage");
        hitPoints = hitPoints - damage;
        if(hitPoints <= 0)
        {
            GameObject deathFX = ObjectPooler.SharedInstance.GetPooledObject(deathEffect.tag);
            if(deathFX)
            {
                deathFX.transform.position = transform.position;
                deathFX.transform.rotation = transform.rotation;
                deathFX.SetActive(true);
            }
            gameObject.SetActive(false);
            // play some cool FX here
        }
    }


    private void OnLifePickup(GameObject pickupDoDestroy)
    {
        pickupDoDestroy.SetActive(false);
        if(hitPoints <= hitPointCap)
        {
            print("Player :: hp up");
            hitPoints++;
        }
        
    }
    private void OnLaserPickup(GameObject pickupDoDestroy)
    {
        print("Player :: laser picked up");
        laserAmmo += 30;
    }
}
