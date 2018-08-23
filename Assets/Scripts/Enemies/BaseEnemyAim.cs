using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAim : MonoBehaviour {

    [SerializeField] protected float reloadBetweenAttacks = 2.0f;
    [SerializeField] protected GameObject enemyProjectile;

    private float nextShotTime;

    

    protected string layerToSearch = "Player";
    int searchLayerIndex;
    // Use this for initialization
    void Awake () {
        searchLayerIndex = LayerMask.NameToLayer(layerToSearch);
    }
	
	// Update is called once per frame
	void Update () {

        if(RaycastForPlayer() && checkTimer())
        {
            FireWeapon();
        }

    }

    virtual protected void FireWeapon()
    {
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("EnemyBullet");
        if(bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, 180);
            bullet.SetActive(true);
        }
        else
        {
            print("bullet not found");
        }
    }
    /// <summary>
    /// Checks whether or not enemy ship can fire
    /// if it can, it modifies the timer for next shot
    /// </summary>
    /// <returns>True when enemy is able to attack, otherwise returns false</returns>
     bool checkTimer()
    {
        if (Time.time - nextShotTime > Mathf.Epsilon)
        {
            nextShotTime = Time.time + reloadBetweenAttacks;
            return true;
        }
        else return false;
    }

    bool RaycastForPlayer()
    {

        RaycastHit2D hitResult = Physics2D.Raycast(transform.position, Vector2.down, 1000.0f, searchLayerIndex, 0.05f, 1.0f);
        if (hitResult.collider != null)return true;
        else return false;
    }
}
