using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    [Tooltip("Number of hits that enemy takes before being destroyed.")]
    private int hitpoints = 5;

    [SerializeField]
    [Tooltip("Score points earned for hitting the enemy")]
    private int scoreForHit;

    [SerializeField]
    [Tooltip("Score points awarded for destroying enemy")]
    private int scoreForKill;

	void Start () {
		
	}
	
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bounds"))
        {
            gameObject.SetActive(false);
        }
        else if(hitpoints <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            hitpoints--;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("ship collided");
    }
}
