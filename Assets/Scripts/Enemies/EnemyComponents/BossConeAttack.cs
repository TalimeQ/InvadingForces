using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossConeAttack : BaseEnemyAim {

    // [SerializeField][Tooltip("If it will be casted after time period or on X amount of hp lost")] bool onHpLost;

    [SerializeField] int numberOfShots = 10;
    [SerializeField] [Tooltip("Cooldown between shots in waves")] float shotInternalCD = 0.1f;
    [SerializeField] [Tooltip("Cone Angle")][Range(0,360)] float angle = 90;
  
	// Use this for initialization
	void Start () {
   
	
	}

    // Update is called once per frame
    void Update()
    {
        if (RaycastForPlayer() && checkTimer())
        {
            StartCoroutine(shootLasers());
        }
    }
   
    IEnumerator shootLasers()
    {
        for(int i = 0; i < numberOfShots; i ++)
        {
            FireWeapon();
            yield return new WaitForSeconds(shotInternalCD);
        }
        
    }
    protected override void FireWeapon()
    {
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("EnemyBullet");
        if(bullet)
        {
            bullet.transform.position = gameObject.transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, 0, -180 + Random.Range(-(angle / 2) , (angle / 2)));
            bullet.SetActive(true);
            base.shootAudioSource.PlayOneShot(base.shootSound);
        }
    }
}
