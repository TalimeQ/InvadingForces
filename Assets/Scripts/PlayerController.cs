using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // TODO : przeniesc to wszystko to skryptu ogarniajacego player shooting, tutaj robi sie za duzy syf.
    
    
    [Header("Movement")]
    [Tooltip("X speed of the starship")]
    [SerializeField] private float ySpeed = 2.0f;
    [Tooltip("Y speed of the starship")]
    [SerializeField] private float xSpeed = 2.0f;

   

    [Header("Shooting")]
    [Tooltip("An bullet gameobject used for basic shoot method")]
    [SerializeField] GameObject defaultBullet;
    [Tooltip("Time between cannon reload")]
    [SerializeField] float reloadTime = 1.0f;
    private float NextFireTime = 0;
    public GameObject DefaultBullet {  get{ return defaultBullet; } }
    bool isLaserActive;


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

        if (Input.GetButton("Fire1")) ProcessShooting();
        if (Input.GetButton("WeaponSwap")) ProcessWeaponSwap();
    }
    private void ProcessWeaponSwap()
    {
        print("SWITCHING WEAPON!");
        isLaserActive = !isLaserActive;
        


        // weapon switching code here.
    }
    private void ProcessShooting()
    {
      
     //  print("Last firing time: " + lastFiringTime + " Time with reload)
            if(NextFireTime <= Time.time)
        { 
            Instantiate(defaultBullet, gameObject.transform.localPosition, Quaternion.Euler(0, 0, 0));
            NextFireTime = Time.time + reloadTime;
            if (isLaserActive) print("FIRING LASURS");
            else print("FIRING PLEB WEAPONS!");
        }
        // TODO :: Zastanowic sie czy strzelanie nie powinno byc osobnym komponentem wywolywanym tylko z playerControllera.

        // przypisac mu jakies wlasciwosci;


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
        
    
       
       
        // TODO some clamping so the player dont leaves the map.





       // transform.localPosition = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);
    }
}
