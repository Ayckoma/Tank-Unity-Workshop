using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float VitesseLancer = 75.0f;
    public GameObject objectPrefab;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            SpawnObj();
        }
    }
    void SpawnObj()
    {
        Vector3 SpawnPosition = transform.position;
        Quaternion SpawnRotation = Quaternion.identity;

        Vector3 localXDirection = transform.TransformDirection(Vector3.forward);
        Vector3 velocity = localXDirection * VitesseLancer;

        GameObject newObject = Instantiate(objectPrefab, SpawnPosition, SpawnRotation);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = velocity;
    }
}
