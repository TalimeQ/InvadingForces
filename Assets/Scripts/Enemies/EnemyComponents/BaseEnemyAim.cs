using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAim : MonoBehaviour {

    [SerializeField] protected float reloadBetweenAttacks = 2.0f;
    [SerializeField] protected GameObject enemyProjectile;

    private float nextShotTime;

    [SerializeField]
    protected AudioSource shootAudioSource;
    [SerializeField]
    protected AudioClip shootSound;

    protected string layerToSearch = "CollisionIgnore";
    int searchLayerIndex;
    // Use this for initialization
    void Awake () {
        searchLayerIndex = LayerMask.NameToLayer(layerToSearch);
        shootAudioSource = this.gameObject.GetComponent<AudioSource>();
    }
	
   
	// Update is called once per frame
	void Update () {
      

        if (RaycastForPlayer() && checkTimer())
        {

            FireWeapon();
        }

    }
    protected void PlayShootSound()
    { 
        if(!shootAudioSource)
        {
            Debug.Log("Skrypt probowal zagrac dzwiek na: " + gameObject.name + " niestety, brakuje mu audiosource");

            return;
        }
        if (!shootSound)
        {
            Debug.Log("Skrypt probowal zagrac dzwiek na: " + gameObject.name + " niestety, nie dodales do niego dzwieku strzalu");
            return;
        }
        shootAudioSource.PlayOneShot(shootSound);
        
    }
    virtual protected void FireWeapon()
    {
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("EnemyBullet");
        if(bullet != null)
        {
            
            PlayShootSound();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, 180);
            bullet.SetActive(true);
        }
        else
        {
           
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

        RaycastHit2D hitResult = Physics2D.Raycast(transform.position, Vector2.down, 1000.0f, searchLayerIndex, 0.00f, 1.0f);
     
        if (hitResult.collider != null)return true;
        
        else return false;
    }
}
