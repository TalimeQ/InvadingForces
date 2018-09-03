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

    protected SpriteRenderer spriteRendererRef;
    [SerializeField]
    Sprite DamageSprite;
    protected Sprite normalSprite;

    IWeaponSwapListener weaponSwapListener;
    ILifeListener playerLifeListener;
    IPlayerDeathListener playerDeathListener;

    private void Start()
    {
        hitPoints = hitPointCap;
        playerAudioSource = gameObject.GetComponent<AudioSource>();
        weaponSwapListener = FindObjectOfType<WeaponSwapper>();
        playerLifeListener = FindObjectOfType<LifeDisplayer>();
        playerDeathListener = FindObjectOfType<GameFinalizer>();
        spriteRendererRef = GetComponent<SpriteRenderer>();
        normalSprite = spriteRendererRef.sprite;
    }
    private void ProcessWeaponSwap()
    {
        isLaserActive = !isLaserActive;
        weaponSwapListener.OnWeaponSwap(isLaserActive);
        

    }
    private void ProcessShooting()
    {

        
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

        hitPoints = hitPoints - damage;
        StartCoroutine(OnDamage());
        playerLifeListener.OnLifeLost(damage);
        if (hitPoints <= 0) 
        {
            GameObject deathFX = ObjectPooler.SharedInstance.GetPooledObject(deathEffect.tag);
            if(deathFX)
            {
                deathFX.transform.position = transform.position;
                deathFX.transform.rotation = transform.rotation;
                deathFX.SetActive(true);
            }
            gameObject.SetActive(false);
            playerDeathListener.OnPlayerDeath();
            
        }
    }


    private void OnLifePickup(GameObject pickupDoDestroy)
    {
        pickupDoDestroy.SetActive(false);

        if(hitPoints < hitPointCap)
        {

            hitPoints++;
            playerLifeListener.OnLifeGained();
        }
        
    }
    private void OnLaserPickup(GameObject pickupDoDestroy)
    {

        laserAmmo += 30;
    }
    IEnumerator OnDamage()
    {
        for (int i = 0; i < 3; i++)
        {
            spriteRendererRef.sprite = DamageSprite;
            yield return new WaitForSeconds(0.15f);
            spriteRendererRef.sprite = normalSprite;
        }

    }
}
