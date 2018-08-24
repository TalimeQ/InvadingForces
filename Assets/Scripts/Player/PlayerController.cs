﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // TODO : przeniesc to wszystko to skryptu ogarniajacego player shooting, tutaj robi sie za duzy syf.


    [Header("Movement")]
    [Tooltip("X speed of the starship")]
    [SerializeField] private float ySpeed = 2.0f;
    [Tooltip("Y speed of the starship")]
    [SerializeField] private float xSpeed = 2.0f;

    PlayerCombat combatComponent;



    private void Start()
    {
        // zapytac sie kogos inteligetnego czemu tutaj bez tego nie dziala, a w collisions dziala.
        combatComponent = FindObjectOfType<PlayerCombat>();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        ProcessMovement();
        if(combatComponent != null)
        { 
        if (Input.GetButton("Fire1")) SendMessage("ProcessShooting");
        if (Input.GetButton("WeaponSwap")) SendMessage("ProcessWeaponSwap");
        }
    }
   

    private void ProcessMovement()
    {

        // sprite jest w rotacji 90 stopni co zmienilo troszke pojecie ktora linia jest vertical a ktora horizontal.
        float verticalThrow = Input.GetAxis("Vertical");
        float verticalMovementRate = verticalThrow * Time.deltaTime * xSpeed;
        float yNewRawPosition = transform.localPosition.y + verticalMovementRate;

        // Moze obnazyc designerowi?
        float yNewPosition = Mathf.Clamp(yNewRawPosition, -4.5f, 4.5f);

        transform.localPosition = new Vector3(transform.localPosition.x, yNewPosition, transform.localPosition.z);

        float horizontalThrow = Input.GetAxis("Horizontal");
        float horizontalMovementRate = horizontalThrow * Time.deltaTime * ySpeed;
        float xNewRawPosition = transform.localPosition.x + horizontalMovementRate;

        // To tez mozna by obnazyc mnie w designerskim kapeluszu :>
        float xNewPosition = Mathf.Clamp(xNewRawPosition, -8f, 8f);

        transform.localPosition = new Vector3(xNewPosition, transform.localPosition.y, transform.localPosition.z);
        
    }
}
