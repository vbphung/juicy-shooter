using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected GameObject spawnObject;
    [SerializeField] protected int poolSize;

    protected int currentSize;
    protected Queue<GameObject> pool;

    private void Awake()
    {
        pool = new Queue<GameObject>();
    }

    public virtual GameObject SpawnObject(GameObject currentObject = null)
    {
        if (currentObject == null)
            currentObject = spawnObject;

        GameObject spawnedObject = null;

        if (currentSize < poolSize)
        {
            spawnedObject = Instantiate(currentObject, transform.position, Quaternion.identity);
            spawnedObject.name += " " + currentSize.ToString();
        }
        else
        {
            spawnedObject = pool.Dequeue();
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
        }

        pool.Enqueue(spawnedObject);
        return spawnedObject;
    }
}