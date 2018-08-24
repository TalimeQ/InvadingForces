using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    PlayerCombat playerCombat;

	// Use this for initialization
	void Start () {
        playerCombat = GetComponent<PlayerCombat>();
	}

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch( collision.tag)
        {
            case "Meteor":
                print("Player :: meteor triggered");
                break;
            case "EnemyBullet":
                print("Player :: enemy bullet triggered");
                SendMessage("ProcessHit", 1);
                break;
            case "EnemyShip1":
                print("Player :: enemy ship triggered");
                break;
            case "EnemyShip2":
                print("Player :: enemy ship 2 triggered");
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
