using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    [Header("Damage Values")]
    [SerializeField]
    int largeShipCollisionDamage = 3;
    [SerializeField]
    int smallShipCollisionDamage = 2;
    [SerializeField]
    int enemyBulletCollisionDamage = 1;
    [SerializeField]
    int meteorCollisionDamage = 2;
    ScoreBoard scoreBoardRef;
    int scorePerScorePickup = 2;
    // Use this for initialization
    private void Start()
    {
        scoreBoardRef = FindObjectOfType<ScoreBoard>();
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch( collision.tag)
        {
            case "Meteor":
                SendMessage("ProcessHit", meteorCollisionDamage);
                break;
            case "EnemyBullet":
                SendMessage("ProcessHit", enemyBulletCollisionDamage);
                break;
            case "EnemyShip1":
                SendMessage("ProcessHit", smallShipCollisionDamage);
                break;
            case "EnemyShip2":
                SendMessage("ProcessHit", largeShipCollisionDamage);
                break;
            case "HpPickup":
                SendMessage("OnLifePickup",collision.gameObject);
                break;
            case "LaserPickup":
                SendMessage("OnLaserPickup", collision.gameObject);
                break;
            case "ScorePickup":
                scoreBoardRef.addScore(scorePerScorePickup);
                break;
            default:
                Debug.LogWarning("Player Collision :: Unknown Trigger Collision");
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogWarning("Player Collision :: Unknown Trigger Collision");
    }
}
