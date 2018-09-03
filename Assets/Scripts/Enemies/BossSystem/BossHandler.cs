
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Invading.Global;
[System.Serializable]
 public struct BossSpawnParameters
{
    [Tooltip("Prefab of object to spawn")]
    public GameObject objectToSpawn;
    [Tooltip("Should Wave Spawner Spawn waves")]
    public bool turnWaves;
    [Tooltip("Should meteors be enabled in waves")]
    public bool turnMeteors;


}
public class BossHandler : MonoBehaviour , IScoreBoardListener , IBossEnemyListener{


   [SerializeField]
    private List<BossSpawnParameters> BossesToSpawn = new List<BossSpawnParameters>();
    private int tableLenght;
  
    private int randomBoss;

    public IBossListener waveBossListener;
    public IBossListener meteorBossListener;
    public IBossListener scoreBoardListener;
    public IBossListener musicPlayerListener;
    
    // TODO ZABEZPIECZYC TA FUNKCJE PRZED NULLAMI W TABLICY


	// Use this for initi alization
	void Start () {

        ScoreBoard scoreBoard = FindObjectOfType<ScoreBoard>();
        scoreBoard.onScoreListener = this;

            tableLenght = BossesToSpawn.Count;

        musicPlayerListener = FindObjectOfType<MusicPlayer>();


    }
	

    public BossSpawnParameters GetBossToSpawn()
    {
        randomBoss = UnityEngine.Random.Range(0,tableLenght);
        return BossesToSpawn[randomBoss] ;
    }

    



    public void OnScoreReached()
    {
        SpawnBoss();
    }

    private void SpawnBoss()
    {
        Vector3 SpawnCoords = new Vector3(0, 0, 0);
        BossSpawnParameters BossToSpawnParams = GetBossToSpawn();
        GameObject BossToSpawn = BossToSpawnParams.objectToSpawn;


        GameObject SpawnedBoss = Instantiate(BossToSpawn, SpawnCoords, Quaternion.Euler(0,0,-90),this.transform);

      

        waveBossListener.OnBossEnter(BossToSpawnParams.turnWaves);
        meteorBossListener.OnBossEnter(BossToSpawnParams.turnMeteors);
        musicPlayerListener.OnBossEnter(false);
    }

    public void SignalizeDeath()
    {
        waveBossListener.OnBossDeath();
        meteorBossListener.OnBossDeath();
        scoreBoardListener.OnBossDeath();
        musicPlayerListener.OnBossDeath();
    }
}
