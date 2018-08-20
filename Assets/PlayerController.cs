using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Tooltip("X speed of the starship")]
    [SerializeField] private float ySpeed = 2.0f;
    [Tooltip("Y speed of the starship")]
    [SerializeField] private float xSpeed = 2.0f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        ProcessMovement();

        if (Input.GetButton("Fire1")) print("Firing");
    }

    private void ProcessMovement()
    {
        float verticalThrow = Input.GetAxis("Vertical");
        float verticalMovementRate = verticalThrow * Time.deltaTime * xSpeed;
        float yNewRawPosition = transform.localPosition.y + verticalMovementRate;
    
        print("Y new position :: " + yNewRawPosition);
       
        transform.localPosition = new Vector3(transform.localPosition.x, yNewRawPosition, transform.localPosition.z);

        float horizontalThrow = Input.GetAxis("Horizontal");
        float horizontalMovementRate = horizontalThrow * Time.deltaTime * ySpeed;
        float xNewRawPosition = transform.localPosition.x + horizontalMovementRate;
        print("X new position :: " + xNewRawPosition);
        transform.localPosition = new Vector3(xNewRawPosition, transform.localPosition.y, transform.localPosition.z);

       
       
        // TODO some clamping so the player dont leaves the map.





       // transform.localPosition = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);
    }
}
