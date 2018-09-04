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

    protected SpriteRenderer spriteRendererRef;
    [SerializeField]
    Sprite DamageSprite;
    protected Sprite normalSprite;

    private IEnemyListener enemyDeathListener;

    void Start () {
       scoreBoard = FindObjectOfType<ScoreBoard>();
        PickupSpawner pickupSpawner = FindObjectOfType<PickupSpawner>();
        spriteRendererRef = GetComponent<SpriteRenderer>();
        normalSprite = spriteRendererRef.sprite;
        enemyDeathListener = pickupSpawner;
		
	}


    private void OnEnable()
    {
        currentHitpoints = hitPoints;
        if (!spriteRendererRef) return;
        spriteRendererRef.sprite = normalSprite;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
           

            case "Bounds":
                gameObject.SetActive(false);
                break;
            case "Meteor":
                ProcessEnemyDeath("Meteor");
                break;
            case "Player":
                ProcessEnemyDeath("Player");
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
        if (gameObject.activeInHierarchy == false) return;
        StartCoroutine(SignalDamaged());
        if(other.tag != "Player")
        { 
        other.SetActive(false);
        }
        if (currentHitpoints <= 0)
        {
            ProcessEnemyDeath("");
        }
        else
        {
            scoreBoard.addScore(scoreForHit);
        }
    }

    protected virtual void ProcessEnemyDeath(string tag)
    {
        enemyDeathListener.OnEnemyDeath(gameObject.transform, bonusDropChance);

        gameObject.SetActive(false);
        SpawnFX(1);
        if (tag == "")
        {
            scoreBoard.addScore(scoreForKill);
        }

    }

    protected void SpawnFX(float scale)
    {
        GameObject deathEffect = ObjectPooler.SharedInstance.GetPooledObject(deathFX.tag);
        if (deathEffect)
        {
            deathEffect.transform.position = this.transform.position;
            deathEffect.transform.rotation = Quaternion.identity;
            deathEffect.transform.localScale = new Vector3(scale, scale, scale);
            deathEffect.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
    protected IEnumerator SignalDamaged()
    {

        for (int i = 0; i < 3 ; i++)
        {
            spriteRendererRef.sprite = DamageSprite;
            yield return new WaitForSeconds(0.15f);
            spriteRendererRef.sprite = normalSprite;
        }
       
    }
}
