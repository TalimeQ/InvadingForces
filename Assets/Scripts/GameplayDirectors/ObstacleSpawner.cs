using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Class used for spawning enviromental obstacles and enviroments
 * in current state it spawns only meteors :<
 * but soon it shall be better and stronger
 * 
 * 
 * 
 */
public class ObstacleSpawner : MonoBehaviour, IBossListener {


    [Header("Enviromental Obstacle Spawning")]
    [Range(0, 10)] [Tooltip("Delay between meteor spawns.")]
    [SerializeField] float spawnDelayInSeconds = 4 ;
    [Tooltip("Grace period in which meteors do not spawn.")]
    [SerializeField] float gracePeriod = 5.0f;
    [Tooltip("Whether or not should to randomize meteor speed")]
    [SerializeField] bool randomSpeed = true;
    [Tooltip("Max meteor speed")]
    [SerializeField]
    float maxSpeed = 4.0f;
    [Tooltip("Min meteor speed")]
    [SerializeField]
    float minSpeed = 1.0f;
    [SerializeField] float minY = -4, maxY = 2;
    bool spawnMeteors = true;

    void Start() {
        BossHandler bossHandle = FindObjectOfType<BossHandler>();
        bossHandle.meteorBossListener = this;
        StartCoroutine(SpawnMeteors());
    }

    void Update() {

    }
    Vector3 prerandomizeSpawnPosition()
    {


        float vectorY = Random.Range(minY, maxY);
        if (Random.Range(0, 3)  == 1)
        {
            return new Vector3(8, vectorY, 0);
            // Fajnie by bylo zeby przylatywal zza ekranu :)
        }
        else
        {
            return new Vector3(-8, vectorY, 0);
        }
    }
    Quaternion prerandomizeSpawnRotation(Vector3 spawnPosition)
    {
        if(spawnPosition.x >= 0)
        {
            return Quaternion.identity;
        }
        else
        {
            return Quaternion.Euler(0, 0, 180);
        }
    }


    IEnumerator SpawnMeteors()
        {
        yield return new WaitForSeconds(gracePeriod);
        while(true)
        {

            
            Vector3 spawnPosition = prerandomizeSpawnPosition();
            Quaternion spawnRotation = prerandomizeSpawnRotation(spawnPosition);
            GameObject meteor = ObjectPooler.SharedInstance.GetPooledObject("Meteor");
            if(meteor != null && spawnMeteors)
            {
                meteor.transform.position = spawnPosition;
                meteor.transform.rotation = spawnRotation;
                Meteor meteorComp = meteor.GetComponent<Meteor>();
                if(randomSpeed)
                {
                    meteorComp.FloatingSpeed = Random.Range(minSpeed, maxSpeed);
                }
                meteor.SetActive(true);
            }

            yield return new WaitForSeconds(spawnDelayInSeconds);
        }
        }

    void IBossListener.OnBossEnter(bool wavesTurned)
    {
        spawnMeteors = wavesTurned;
    }

    void IBossListener.OnBossDeath()
    {
        spawnMeteors = true;
    }
}
