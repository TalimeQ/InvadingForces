using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteor : MonoBehaviour {

    // TODO DODAC SPAWN METEOROW.



    bool isMovingLeft = true;
    // whether or not is moving in a slightly curvish manner ;) default 0

    

    // Should be randomized for more funzies
    [SerializeField]
    float floatingSpeed = 2.0f;
    public float FloatingSpeed { set { floatingSpeed = value; } }

    private Rigidbody2D meteorBody;

	// Use this for initialization
	void Awake () {
      //  meteorBody = FindObjectOfType<Rigidbody2D>();
	}
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
    // Update is called once per frame
    void Update () {
        processMeteorMovement();
       
		
	}

    private void processMeteorMovement()
    {
        // Todo:: w zwiazku ze respi sie z boku , powinien zaczac lot wolniej aby potem przyspieszyc do makysmalnej wartosci.
        // Jakas prosta funkcja liniowa styknie.
        if(isMovingLeft)
        {

            // ten vector nie jest relatywny trzeba by zmienic na szajs z enemy.


            transform.localPosition = transform.localPosition + Vector3.left * Time.deltaTime * floatingSpeed;
        }
        else
        {
            transform.localPosition = transform.localPosition + Vector3.right * Time.deltaTime * floatingSpeed;

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO :: ADD POOLING

        gameObject.SetActive(false);
        collision.gameObject.SetActive(false);
        Debug.LogWarning("Meteor ::  Collided with something");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        if(!collision.CompareTag("Bounds"))
        { collision.gameObject.SetActive(false); }
        
        Debug.LogWarning("Meteor ::  Trigered something");
    }
}
