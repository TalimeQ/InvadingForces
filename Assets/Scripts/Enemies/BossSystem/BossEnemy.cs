using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy {

    public IBossEnemyListener bossDeathListener;
    [SerializeField] private AudioClip bossEntranceSound;
    [SerializeField] AudioSource audioSource;
    // Use this for initialization
    void Start() {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        audioSource = GetComponent<AudioSource>();
        BossHandler bossHandler = FindObjectOfType<BossHandler>();
        spriteRendererRef = GetComponent<SpriteRenderer>();
        normalSprite = spriteRendererRef.sprite;
        bossDeathListener = bossHandler;
    }

    // Update is called once per frame
    void Awake()
    {
        if(audioSource != null)
        { 
        audioSource.PlayOneShot(bossEntranceSound);
        }
        if(!spriteRendererRef) return;
        spriteRendererRef.sprite = normalSprite;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
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
    protected override void ProcessEnemyDeath(string tag)
    {
        bossDeathListener.SignalizeDeath();
        scoreBoard.addScore(scoreForKill);
        SpawnFX(1.6f);
        Destroy(gameObject);
        
        
    }
}
