﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    [Tooltip("Number of hits that enemy takes before being destroyed.")]
    private int hitPoints = 5;
    private int currentHitpoints = 5;

    [SerializeField]
    [Tooltip(" Adds +% to pickup drop chance")]
    int bonusDropChance = 0;

    [SerializeField]
    [Tooltip("Score points earned for hitting the enemy")]
    protected int scoreForHit;

    [SerializeField]
    [Tooltip("Score points awarded for destroying enemy")]
    protected int scoreForKill;

    protected ScoreBoard scoreBoard;
   
    private IEnemyListener enemyDeathListener;

    void Start () {
       scoreBoard = FindObjectOfType<ScoreBoard>();
        PickupSpawner pickupSpawner = FindObjectOfType<PickupSpawner>();
        enemyDeathListener = pickupSpawner;
		
	}


    private void OnEnable()
    {
        currentHitpoints = hitPoints;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    switch (collision.tag)
        {
            case "Bounds":
                gameObject.SetActive(false);
                break;
            case "Meteor":
                gameObject.SetActive(false);
                break;
            case "Player":
                gameObject.SetActive(false);
                break;
            case "Bullet":
                ManageLife(collision.gameObject, 1);
                break;
            case "LaserProj":
                ManageLife(collision.gameObject, 2);
                break;
            default:
                break;

        }
    }

    protected void ManageLife(GameObject other, int deductedHP)
    {
        Debug.Log("Player :: collision with ENEMY 2"); 
        currentHitpoints -= deductedHP;
        if(currentHitpoints <= 0)
        {
            ProcessEnemyDeath(other);
        }
        else
        {
            scoreBoard.addScore(scoreForHit);
        }
    }

    protected virtual void ProcessEnemyDeath(GameObject other)
    {
        enemyDeathListener.OnEnemyDeath(gameObject.transform,bonusDropChance);
        gameObject.SetActive(false);
        other.SetActive(false);
        scoreBoard.addScore(scoreForKill);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("ship collided");
    }

}
