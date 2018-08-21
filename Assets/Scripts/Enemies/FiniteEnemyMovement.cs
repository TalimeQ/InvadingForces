using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteEnemyMovement : RandomEnemyMovement {

    [Header("Finite movement")]
    [SerializeField] private int minMovementLoops = 2;
    [SerializeField] private int maxMovementLoops = 5;

    [SerializeField] private float downwardSpeed = 0.5f;
    int movementLoops = 3;
    Rigidbody2D movementBody;
    Vector2 velocity;

    // Use this for initialization
    void Start () {
        randomizeMovementLoops();
        CalculateMovementParameters();
        movementBody = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, -downwardSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        if(movementLoops > 0)
        { 
        InterpolateMovement();
        }
        else
        {
            Debug.Log("WE MOVIN DOWN BOIS");
            MoveDownwards();
        }
    }
    void randomizeMovementLoops()
    {
        movementLoops =  Random.Range(minMovementLoops, maxMovementLoops);
    }
    protected override bool CheckMovementRequirements(float interpolationTime)
    {
        if (interpolationTime >= 1 && movementLoops > 0)
        {
            // TODO :: Znalez sensowny sposob na refaktor, narazie nie da sie tego stad ruszyc bo movementLoopsy cos musi zmniejszac.
            movementLoops--;
            return true;
        }
        else return false;

    }
    void MoveDownwards()
    {
        movementBody.MovePosition(movementBody.position + velocity * Time.deltaTime);
    }
}
