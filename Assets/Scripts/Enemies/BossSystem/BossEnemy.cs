﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy {

    public IBossEnemyListener bossDeathListener;
	// Use this for initialization
	void Start () {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        BossHandler bossHandler = FindObjectOfType<BossHandler>();
        bossDeathListener = bossHandler;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(gameObject.name + " Collided from boss");
        switch (collision.tag)
        {

            case "Meteor":
                ManageLife(collision.gameObject, 1);
                break;
            case "Player":
                ManageLife(collision.gameObject, 1);
                break;
            case "Bullet":
                ManageLife(collision.gameObject, 1);
                break;
            case "LaserProj":
                ManageLife(collision.gameObject, 3);
                break;
            default:
                break;

        }
    }
    protected override void ProcessEnemyDeath()
    {
        bossDeathListener.SignalizeDeath();
        scoreBoard.addScore(scoreForKill);
        
        Destroy(gameObject);
        
        
    }
}
