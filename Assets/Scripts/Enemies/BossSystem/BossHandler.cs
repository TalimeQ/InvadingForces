
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
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
    // array nie jest dynamiczny odpada, lista niby guczi ale srednio sie z niej wyciaga okreslone elementy, slownik wyjdzie spoko
    Dictionary<int, bool> wasNotUsed = new Dictionary<int, bool>();
    private int randomBoss;

    public IBossListener waveBossListener;
    public IBossListener meteorBossListener;
    public IBossListener scoreBoardListener;
    
    // TODO ZABEZPIECZYC TA FUNKCJE PRZED NULLAMI W TABLICY


	// Use this for initi alization
	void Start () {

        ScoreBoard scoreBoard = FindObjectOfType<ScoreBoard>();
        scoreBoard.onScoreListener = this;
        // Jesli tablica jest pusta, to w sumie skrypt nie ma co robic
  
            tableLenght = BossesToSpawn.Count;
       
            // inicjalizacja slownika
            for (int i = 0; i < tableLenght; i++)
            {
            wasNotUsed.Add(i, true);
            }



    }
	

    public BossSpawnParameters GetBossToSpawn()
    {
        randomBoss = UnityEngine.Random.Range(0,tableLenght);
     
        while(!CheckIfWasSpawned(randomBoss))
        {
            randomBoss = UnityEngine.Random.Range(0, tableLenght);
        }
        print("Wylosowano bossa " + BossesToSpawn[randomBoss].objectToSpawn.name + " Nastepny index " );
        return BossesToSpawn[randomBoss] ;
    }
    private bool CheckIfWasSpawned(int key)
    {
        if(CheckIfDictionaryFull())
        {
            ResetBosses();
        }
 
        if (wasNotUsed[key])
        {
            wasNotUsed[key] = false;
            return false;
        }
            else
            {
                return true;
            }
        }

   
       

    

    private void ResetBosses()
    {
        for(int i = 0; i < tableLenght; i++)
        {
            wasNotUsed[i] = true;
        }
    }

    private bool CheckIfDictionaryFull()
    {
        // czy dictionary zapelnione
        int numerator = 0;
        for (int i = 0; i < tableLenght; i++)
        {

                if (wasNotUsed[i] == false) numerator++;

                return false;

        }
        if (numerator == BossesToSpawn.Count)
        {
            // trzeba wyczyscic tablice
            return true;
        }
        else
        {
            return false;
        }
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
        print(BossToSpawnParams.objectToSpawn);


        GameObject SpawnedBoss = Instantiate(BossToSpawn, SpawnCoords, Quaternion.Euler(0,0,-90),this.transform);

        SpawnedBoss.GetComponent<BossEnemy>().bossDeathListener = this;

        waveBossListener.OnBossEnter(BossToSpawnParams.turnWaves);
        meteorBossListener.OnBossEnter(BossToSpawnParams.turnMeteors);
    }

    public void SignalizeDeath()
    {
        waveBossListener.OnBossDeath();
        meteorBossListener.OnBossDeath();
    }
}
