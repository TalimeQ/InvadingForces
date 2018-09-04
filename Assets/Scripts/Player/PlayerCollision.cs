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


    [SerializeField]
    AudioClip pickupClip;
    [SerializeField]
    AudioSource playerAudioSource;

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
                PlayPickupSound();
                SendMessage("OnLifePickup",collision.gameObject);
                break;
            case "LaserPickup":
                PlayPickupSound();
                SendMessage("OnLaserPickup", collision.gameObject);
                break;
            case "ScorePickup":
                PlayPickupSound();
                scoreBoardRef.addScore(scorePerScorePickup);
                break;
            default:
                Debug.LogWarning("Player Collision :: Unknown Trigger Collision with object " + collision.gameObject.name);
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.LogWarning("Player Collision :: Unknown Trigger Collision");
    }
    void PlayPickupSound()
    {
        playerAudioSource.PlayOneShot(pickupClip);
    }
}
