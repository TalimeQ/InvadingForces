using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour , IEnemyListener {

    [SerializeField]
    int BasePickupChance = 15;
    [SerializeField]
    int ScorePickupChance = 35;
    public void OnEnemyDeath(Transform deathPos,int chanceBonus)
    {
       
      if(RollForPickupChance(chanceBonus))
        {
            string pickupTag = RollForPickup();
            SpawnPickup(pickupTag,deathPos);
        }
      else if(RollForScorePickupChance(chanceBonus))
        {
            SpawnPickup("ScorePickup",deathPos);
        }
    }

    // Use this for initialization
    void Start () {
    
        BasePickupChance = 100 - BasePickupChance;
        ScorePickupChance = 100 - ScorePickupChance;

    }
	


    /// <summary>
    /// returns whater or not game should drop bonus
    /// </summary>
    /// <param name="chanceBonus"> additional chance to drop additive </param>
    /// <returns></returns>
    bool RollForPickupChance(int chanceBonus)
    {
        float chance = Random.Range(0.0f, 100.0f) + chanceBonus;
        if (chance - BasePickupChance > Mathf.Epsilon) return true;
        return false;
    }
    /// <summary>
    ///  returns wheter or not game should drop score bonus
    /// </summary>
    /// <param name="chanceBonus"> additional, additive chance to drop </param>
    /// <returns></returns>
    bool RollForScorePickupChance(int chanceBonus)
    {
        float chance = Random.Range(0.0f, 100.0f) + chanceBonus;
        if (chance - ScorePickupChance > Mathf.Epsilon) return true;
        return false;
    }
    /// <summary>
    /// 
    /// Rolls if it should drop weapon pickup or utility pickup
    /// </summary>
    /// <returns></returns>
    string RollForPickup()
    {
        int whatToDrop = Random.Range(1, 4);
        if(whatToDrop >= 3)
        {
            return "LaserPickup";
        }
        else
        {
            return "HpPickup";
        }
    }

    void SpawnPickup(string tag,Transform spawnPos)
    {
        GameObject pickup = ObjectPooler.SharedInstance.GetPooledObject(tag);
        if(pickup != null)
        {
            pickup.transform.position = spawnPos.position;
            pickup.transform.rotation = Quaternion.identity;
            pickup.SetActive(true);
        }
        else
        {
            Debug.LogError("PickupSpawner :: could not find pickup with tag " + tag + " to spawn.");
        }
    }
}
