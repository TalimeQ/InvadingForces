using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    [Tooltip("Number of hits that enemy takes before being destroyed.")]
    private int hitPoints = 5;

    private int currentHitpoints = 5;


    [SerializeField]
    [Tooltip("Score points earned for hitting the enemy")]
    private int scoreForHit;

    [SerializeField]
    [Tooltip("Score points awarded for destroying enemy")]
    private int scoreForKill;

    private ScoreBoard scoreBoard;

    void Start () {
       scoreBoard = FindObjectOfType<ScoreBoard>();
		
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
                collision.gameObject.SetActive(false);
                break;
            case "Bullet":
                ManageLife(collision.gameObject);
                break;
            default:
                break;

        }
    }

    private void ManageLife(GameObject other)
    {
        currentHitpoints--;
        if(currentHitpoints <= 0)
        {
            gameObject.SetActive(false);
            other.SetActive(false);
            scoreBoard.addScore(scoreForKill);
        }
        else
        {
            scoreBoard.addScore(scoreForHit);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("ship collided");
    }
}
