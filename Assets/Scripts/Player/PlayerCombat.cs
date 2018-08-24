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

    [Header("Hitpoints and death")]
    [SerializeField]
    int hitPoints = 3;

    public void ProcessWeaponSwap()
    {
        print("SWITCHING WEAPON!");
        isLaserActive = !isLaserActive;



        // weapon switching code here.
    }
    public void ProcessShooting()
    {


        if (NextFireTime <= Time.time)
        {
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Bullet");
            if (bullet != null)
            {
                NextFireTime = Time.time + reloadTime;
                if (isLaserActive) print("FIRING LASURS");
                else print("FIRING PLEB WEAPONS!");
                bullet.transform.rotation = Quaternion.identity;
                bullet.transform.position = gameObject.transform.position + Vector3.up;
                bullet.SetActive(true);
            }

        }
        // TODO :: Zastanowic sie czy strzelanie nie powinno byc osobnym komponentem wywolywanym tylko z playerControllera.




    }

    private void ProcessHit(int damage)
    {
        print("Player :: I've been hit for " + damage + "damage");
        hitPoints = hitPoints - damage;
        if(hitPoints <= 0)
        {   

        }
    }
}
