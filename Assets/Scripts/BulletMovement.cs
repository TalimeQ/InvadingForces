using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {


 
    [Tooltip("Speed of the player projectile.")]
    [SerializeField] float bulletSpeed = 2.0f;
    public float BulletSpeed { get { return bulletSpeed; } }
    private Rigidbody2D bulletBody;



	void Awake () {

      bulletBody =  this.GetComponent<Rigidbody2D>();
        
	}
    private void OnEnable()
    {
        bulletBody.AddForce(transform.up * bulletSpeed);
    }
    void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bounds"))
        {
            gameObject.SetActive(false);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            print("Bullet collided");
        gameObject.SetActive(false);

    }
}
