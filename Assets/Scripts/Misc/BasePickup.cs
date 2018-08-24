﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.CompareTag("Bounds"))
        {
            gameObject.SetActive(false);
        }
       else if(collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
