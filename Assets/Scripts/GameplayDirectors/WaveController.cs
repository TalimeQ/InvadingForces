﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour , IBossListener{
    [Header("Properties")]
    [Tooltip("Grace period between spawning first wave of enemies")]
    [SerializeField] int preparationTime = 10;
    [SerializeField]
    string[] enemySpawnerTags = { "EnemyShip1", "EnemyShip2" };
    [SerializeField]
    private int enemiesToSpawn = 2;
    [SerializeField]
    private float spawnDelay = 0.5f;
    [SerializeField]
    private float spawnInterval = 7.0f;


    bool spawnWaves = true;

    [Header("Spawn Ranges")]
    [SerializeField]
    float maxX = 7.5f;
    float minX = -7.5f;
    float maxY = 4.5f;
    float minY = 4f;

    

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnWaves());

        BossHandler bossHandler = FindObjectOfType<BossHandler>();
        bossHandler.waveBossListener = this;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // TODO : dodac zeby duze statki mialy maksymalna liczbe zrespien
    // mozliwosc blokowania
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(preparationTime);
        while(true)
        {
            for( int i = 0; i < enemiesToSpawn; i++)
            {
                if (spawnWaves) { 
                // Przerobic bo mozna dojsc do faktu ze rng respi nam tylko 2 na zapelnionym 2kami ekranie. co nie respi nic. Chociaz czy to zle?
                Vector3 SpawnPosition = new Vector3(Random.Range(minX,maxX), Random.Range(minY,maxY),0);
                Quaternion spawnRotation = Quaternion.Euler(0,0,-90);
                var spawnedEnemy = ObjectPooler.SharedInstance.GetPooledObject(enemySpawnerTags[Random.Range(0, enemySpawnerTags.Length)]);
                if(spawnedEnemy != null)
                {

                    // TODO :: Fajnie by bylo zeby przeciwnicy przylatywali zza ekranu.
                    spawnedEnemy.transform.position = SpawnPosition;
                    spawnedEnemy.transform.rotation = spawnRotation;
                    spawnedEnemy.SetActive(true);

                }
                }


                yield return new WaitForSeconds(spawnDelay);
            }
            // TODO : USUNAC SZTYWNIAKA
            yield return new WaitForSeconds(spawnInterval);
       // TODO doczytac o delegatach.
        }
    }



    void IBossListener.OnBossEnter(bool wavesTurned)
    {
        spawnWaves = wavesTurned;
    }

    void IBossListener.OnBossDeath()
    {
        spawnWaves = true;
    }
}
