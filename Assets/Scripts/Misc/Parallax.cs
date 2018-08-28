using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
    [SerializeField]
    List<GameObject> scrolledObjects;
    // Use this for initialization
    Vector3 paralaxDirection;
    // bool determining scrolling side
    [Tooltip("Determines if parallax should move horizontaly (true) or verticaly (false)")]
    [SerializeField]
    bool isYDirection = true;
    [Tooltip("Scrolling speed")]
    [SerializeField]
    float scrollValue = 0;
    // scroll cap
    [Tooltip("Position to which stars will be scrolled")]
    [SerializeField]
    float scrollCap;
    [Tooltip(" Position to which stars will be reset after reaching scrollCap")]
    [SerializeField]
    float startPos;


    private void Start()
    {
        // inicjalizacja vektora
        if(isYDirection)
        {
            paralaxDirection = new Vector3(0, scrollValue, 0);
        }
        else
        {
            paralaxDirection = new Vector3(scrollValue, 0 , 0);
        }


    }
    // Update is called once per frame
    void Update () {
        // nie ma co scrollowac jak lista jest pusta
        if (scrolledObjects.Count == 0) return;
		foreach(GameObject parallaxObject in scrolledObjects)
        {
            scrollObject(parallaxObject);
        }

	}
    void scrollObject(GameObject scrolledObject)
    {
        
        scrolledObject.transform.position = scrolledObject.transform.position + paralaxDirection * Time.deltaTime;
        ResetPosition(scrolledObject);
    }
    void ResetPosition(GameObject objectToReset)
    {
        if(isYDirection)
        {
            if (objectToReset.transform.position.y < scrollCap)
            {
                float randomX = Random.Range(-1.0f, 1.0f);
                objectToReset.transform.position = new Vector3(randomX, startPos, 0);
            }
            else
            {
                return;
            }
            
        }
        else
        {
            if (objectToReset.transform.position.x < scrollCap)
            {
                float randomY = Random.Range(-1.0f, 1.0f);
                objectToReset.transform.position = new Vector3(startPos, randomY, 0);
            }
        }
    }
}
