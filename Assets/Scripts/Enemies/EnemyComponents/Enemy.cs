using System.Collections;
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
    [SerializeField][Tooltip("Particle effect used on enemy death")]
    protected GameObject deathFX;
   
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
                ProcessEnemyDeath();
                break;
            case "Player":
                ProcessEnemyDeath();
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
        currentHitpoints -= deductedHP;
        other.SetActive(false);
        if(currentHitpoints <= 0)
        {
            ProcessEnemyDeath();
        }
        else
        {
            scoreBoard.addScore(scoreForHit);
        }
    }

    protected virtual void ProcessEnemyDeath()
    {
        enemyDeathListener.OnEnemyDeath(gameObject.transform,bonusDropChance);
       
        gameObject.SetActive(false);
        GameObject deathEffect = ObjectPooler.SharedInstance.GetPooledObject(deathFX.tag);
        if(deathEffect)
        {
            deathEffect.transform.position = this.transform.position;
            deathEffect.transform.rotation = Quaternion.identity;
            deathEffect.SetActive(true);
        }
        
        scoreBoard.addScore(scoreForKill);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
