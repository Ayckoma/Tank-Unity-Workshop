using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    public float VitesseLancer = 75.0f;
    public float delaiEntreTirs = 0.5f; 
    private float tempsDernierTir;

    public GameObject objectPrefab;

    void Start()
    {
        tempsDernierTir = -delaiEntreTirs; 
    }

    public void Inputshoot(InputAction.CallbackContext context)
    {
        
        if (Time.time - tempsDernierTir >= delaiEntreTirs)
        {
            SpawnObj();
            tempsDernierTir = Time.time; 
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


