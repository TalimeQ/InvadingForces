using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectPoolItem{
    public int amountToPool;
    public GameObject objectoPool;
    public bool shouldExpand;
}

public class ObjectPooler : MonoBehaviour {

    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;
    public static ObjectPooler SharedInstance;

    private void Awake()
    {
        SharedInstance = this;
    }
    // Use this for initialization
    void Start () {

        pooledObjects = new List<GameObject>();
        foreach(ObjectPoolItem item in itemsToPool)
        {
            for( int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectoPool);
                obj.transform.SetParent(this.transform);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
	}
	
    public GameObject GetPooledObject(string tag)
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        foreach( ObjectPoolItem item in itemsToPool)
        {
           if(item.objectoPool.tag ==  tag)
            {
                if(item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectoPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
