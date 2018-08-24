﻿using System;
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

    void OnEnable()
    {
        
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
                gameObject.SetActive(false);
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
            default:
                collision.gameObject.SetActive(false);
                gameObject.SetActive(false);
                break;
        }
    }
}