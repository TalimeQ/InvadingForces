using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    // TODO some object pooling

     // wykminiic czy nie lepiej pollowac go po X dystansu zamiast przy kolizji.
    [Tooltip("Speed of the player projectile.")]
    [SerializeField] float bulletSpeed = 2.0f;
    public float BulletSpeed { get { return bulletSpeed; } }
	// Use this for initialization
	void Start () {
        // TODO :: Tymczasowe do refaktoru, cale rozwiazanie jebnie jak trzeba bedzie object poolowac.

       var bulletBody =  this.GetComponent<Rigidbody2D>();
        bulletBody.AddForce(Vector2.up * bulletSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }
        
       // print("bullet triggered");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            print("Bullet collided");
            Destroy(gameObject);
     
    }
}
