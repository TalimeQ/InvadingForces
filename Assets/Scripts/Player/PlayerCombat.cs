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
    private int laserAmmo = 0;


    [Header("Hitpoints and death")]
    int hitPoints = 3;
    [SerializeField]
    int hitPointCap = 3;
    private void Start()
    {
        hitPoints = hitPointCap;
    }
    private void ProcessWeaponSwap()
    {
        isLaserActive = !isLaserActive;
        print("Laser Active!");


        // weapon switching code here.
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
                    NextFireTime = Time.time + reloadTime / 5;
                    laserProj.transform.rotation = Quaternion.identity;
                    laserProj.transform.position = gameObject.transform.position + Vector3.up;
                    laserProj.SetActive(true);
                }
            }

        }
        
 

    }

    private void ProcessHit(int damage)
    {
        print("Player :: I've been hit for " + damage + "damage");
        hitPoints = hitPoints - damage;
        if(hitPoints <= 0)
        {
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
