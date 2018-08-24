﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour , IEnemyListener {

    [SerializeField]
    int BasePickupChance = 15;
    [SerializeField]
    int ScorePickupChance = 35;
    public void OnEnemyDeath(Transform deathPos,int chanceBonus)
    {
        Debug.Log("Want to spawn pickup!");
      if(RollForPickupChance(chanceBonus))
        {
            string pickupTag = RollForPickup();
            SpawnPickup(pickupTag);
        }
      else if(RollForScorePickupChance(chanceBonus))
        {
            SpawnPickup("Money");
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
            return "WeaponPickup";
        }
        else
        {
            return "UtilityPickup";
        }
    }

    void SpawnPickup(string tag)
    {

    }
}
