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
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(hitpoints <= 0)
        {
            // TODO object pooling
            Destroy(gameObject);
        }
        else
        {
            print(hitpoints);
            hitpoints--;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        print("ship collided");
    }
}
