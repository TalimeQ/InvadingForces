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
public class ObstacleSpawner : MonoBehaviour {


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

    // Use this for initialization
    void Start() {
        StartCoroutine(SpawnMeteors());
    }

    // Update is called once per frame
    void Update() {

    }
    // doczytac o referencjach tutaj, bo w sumie tak by bylo lepiej przekazac szajs. i zrobic jedna funkcje zamiast 2
    Vector3 prerandomizeSpawnPosition()
    {


        float vectorY = Random.Range(minY, maxY);
        if (Random.Range(0, 3)  == 1)
        {
            // Respimy po prawej stronie wiec wektory prawostronne
            
            return new Vector3(8, vectorY, 0);
            // Fajnie by bylo zeby przylatywal zza ekranu :)
        }
        else
        {
            return new Vector3(-8, vectorY, 0);
            // Respimy po lewej stronie wiec wektory lewostronne
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

            // wymyslic jak to sie ma dokladnie przeliczac .-.
           
            Vector3 spawnPosition = prerandomizeSpawnPosition();
            Quaternion spawnRotation = prerandomizeSpawnRotation(spawnPosition);
            GameObject meteor = ObjectPooler.SharedInstance.GetPooledObject("Meteor");
            if(meteor != null)
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
            else
            {
                print("dupa");
            }
            

            yield return new WaitForSeconds(spawnDelayInSeconds);
        }
        }
}
