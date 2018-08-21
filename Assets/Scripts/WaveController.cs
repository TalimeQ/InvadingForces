using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {
    [Header("Properties")]
    [Tooltip("Grace period between spawning first wave of enemies")]
    [SerializeField] int preparationTime = 10;
    [SerializeField]
    GameObject[] enemyToSpawn;
    [SerializeField]
    private int enemiesToSpawn = 2;
    [SerializeField]
    private float spawnDelay = 0.5f;

    [Header("Spawn Ranges")]
    [SerializeField]
    float maxX = 7.5f;
    float minX = -7.5f;
    float maxY = 4.5f;
    float minY = 4f;

    

    // Use this for initialization
    void Start () {
        StartCoroutine(SpawnWaves());
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
                Vector3 SpawnPosition = new Vector3(Random.Range(minX,maxX), Random.Range(minY,maxY),0);
                Quaternion spawnRotation = Quaternion.Euler(0,0,-90);
                Instantiate(enemyToSpawn[Random.Range(0,enemyToSpawn.Length)],SpawnPosition,spawnRotation);
                yield return new WaitForSeconds(spawnDelay);
            }
            // TODO : USUNAC SZTYWNIAKA
            yield return new WaitForSeconds(10);
       // TODO doczytac o delegatach.
        }
    }
}
