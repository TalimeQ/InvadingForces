using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyMovement : MonoBehaviour {

    // TODO :: REFACTOR
    [Header("Movement Range")]
    [SerializeField]
    [Tooltip("Maximal  Y  range of movement")]
    private float maxY = 5.0f;
    [SerializeField]
    [Tooltip("X range of movement ")]
    private float maxX = 5.0f;
    // Because i want my ship to move on certain Y's wheras i would certainly have full X axis to work with.
    [SerializeField]
    [Tooltip("Minimal Y range of movement")]
    private float minY = 0.0f;



    private float movementStartingX;
    private float movementStartingY;

    private float movementEndX;
    private float movementEndY;

    [SerializeField]
    [Tooltip("Minimal speed change variable")]
    public float pseudoRandomRangeMin = 0.4f;

    [SerializeField]
    [Tooltip("Maximal speed change variable")]
    public float pseudoRandomRangeMax = 0.5f;

    private float startTime;
    private float movementDuration = 10;

    bool gotInterpolationData = false;

	// Use this for initialization
	void Start () {
        InitializeMovement();

	}
	
	// Update is called once per frame
    void InitializeMovement()
    {
        movementEndX  = Random.Range(-maxX, maxX);
        movementEndY = Random.Range(minY, maxY);


        startTime = Time.time;
        movementStartingX = transform.position.x;
        movementStartingY = transform.position.y;
        gotInterpolationData = true;


        float distance = Vector3.Distance(new Vector3(movementStartingX, movementStartingY, 0), new Vector3(movementEndX, movementEndY, 0));


        float randomDuration = Random.Range(pseudoRandomRangeMin, pseudoRandomRangeMax) * distance;
        movementDuration = Mathf.Abs(randomDuration);

    }
	void Update ()
    {
        InterpolateMovement();

    }

    private void InterpolateMovement()
    {
        float interpolationTime = (Time.time - startTime) / movementDuration;
        transform.position = new Vector3(Mathf.SmoothStep(movementStartingX, movementEndX, interpolationTime),
            Mathf.SmoothStep(movementStartingY, movementEndY, interpolationTime), 0
            );
        if (interpolationTime >= 1)
        {
            gotInterpolationData = false;
        }

        if (gotInterpolationData == false)
        {
            InitializeMovement();
        }
    }
}
