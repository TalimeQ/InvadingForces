using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteor : MonoBehaviour {


    bool isMovingLeft = true;
    // Should be randomized for more funzies
    [SerializeField]
    float floatingSpeed = 2.0f;
    public float FloatingSpeed { set { floatingSpeed = value; } }
    private Rigidbody2D meteorBody;
    [SerializeField]
    private GameObject DeathFX;
    [SerializeField]
    private int hp = 1;
    public int Hp {  set { hp = value; } }

    void OnEnable()
    {
        if(hp <= 0)
        {
            hp = 1;
        }
        if(transform.position.x < 0 )
        {
            isMovingLeft = false;
        }
        else if(transform.position.x > 0)
        {
            isMovingLeft = true;
        }
    }

    void Update ()
    {
        processMeteorMovement();
	}

    private void processMeteorMovement()
    {
        // Todo:: w zwiazku ze respi sie z boku , powinien zaczac lot wolniej aby potem przyspieszyc do makysmalnej wartosci.
        // Jakas prosta funkcja liniowa styknie.
        if(isMovingLeft)
        {



            transform.localPosition = transform.localPosition + Vector3.left * Time.deltaTime * floatingSpeed;
        }
        else
        {
            transform.localPosition = transform.localPosition + Vector3.right * Time.deltaTime * floatingSpeed;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        gameObject.SetActive(false);
        Debug.LogError("Meteor :: collided with" + collision.gameObject);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
 
       
        switch(collision.tag)
        {
            case "Player":
                MeteorDestruction();
                break;
            case "Bounds":
                gameObject.SetActive(false);
                break;
            case "HpPickup":
                break;
            case "LaserPickup":
                break;
            case "ScorePickup":
                break;
            case "Meteor":
                break;
            case   "EnemyBullet":
                ManageHp();
                collision.gameObject.SetActive(false);
                break;
            case "LaserProj":
                ManageHp();
                collision.gameObject.SetActive(false);
                break;
            case "Bullet":
                ManageHp();
                collision.gameObject.SetActive(false);
                break;
            default:
                
                
                MeteorDestruction();
                break;
        }
    }
    void MeteorDestruction()
    {
      GameObject meteorFX =  ObjectPooler.SharedInstance.GetPooledObject(DeathFX.tag);
        if(meteorFX)
        {
            meteorFX.transform.position = transform.position;
            meteorFX.transform.rotation = Quaternion.identity;
            meteorFX.SetActive(true);

        }
        else
        {
      
        }
        gameObject.SetActive(false);
    }
    void ManageHp()
    {
        hp--;
        if(hp <= 0)
        {
            MeteorDestruction();
        }
    }
}
