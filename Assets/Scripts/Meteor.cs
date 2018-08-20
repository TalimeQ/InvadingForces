﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteor : MonoBehaviour {

    bool isMovingLeft = true;
    // whether or not is moving in a slightly curvish manner ;) default 0
    [Range(-1.0f,1.0f)]
    [SerializeField]
    float CurvingValue = 0;

    // Should be randomized for more funzies
    [SerializeField]
    float floatingSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        processMeteorMovement();
       
		
	}

    private void processMeteorMovement()
    {
        if(isMovingLeft)
        {
            transform.localPosition = transform.localPosition + Vector3.left * Time.deltaTime * floatingSpeed;
            transform.localPosition = transform.localPosition + Vector3.up * Time.deltaTime * CurvingValue;
        }
        else
        {
            transform.localPosition = transform.localPosition + Vector3.right * Time.deltaTime * floatingSpeed;
            transform.localPosition = transform.localPosition + Vector3.up * Time.deltaTime * CurvingValue;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO :: ADD POOLING
        
        Destroy(gameObject);
        Destroy(collision.gameObject);
        Debug.LogWarning("Meteor ::  Collided with something");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if(!collision.CompareTag("Bounds"))
        { Destroy(collision.gameObject); }
        
        Debug.LogWarning("Meteor ::  Trigered something");
    }
}
