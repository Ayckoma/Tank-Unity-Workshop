using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour
{
    public int health = 3;
    public GameObject targetPrefab; // Préfabriqué de la cible pour la génération
    public Vector3 sceneMinLimit; // Limite minimale de la scène
    public Vector3 sceneMaxLimit; // Limite maximale de la scène
    public Camera mainCamera;



    void Start()
    {
        // Récupérer les limites de la scène en utilisant le viewport de la caméra principale
        mainCamera = Camera.main;
        sceneMinLimit = mainCamera.ViewportToWorldPoint(Vector3.zero);
        sceneMaxLimit = mainCamera.ViewportToWorldPoint(Vector3.one);
    }

    private void Awake()
    {
        health = 3;
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
        {
            
            Destroy(gameObject);
            SpawnNewTarget(); // Appeler la méthode de génération de cible
            
        }
    }

    private void SpawnNewTarget()
    {
        if(GameObject.FindGameObjectWithTag("SpawnArea").TryGetComponent<Collider>(out  Collider SpawnArea))
        {
            float x= Random.Range(SpawnArea.bounds.min.x, SpawnArea.bounds.max.x);
                    float z= Random.Range(SpawnArea.bounds.min.z, SpawnArea.bounds.max.z);
                    Instantiate(targetPrefab, new Vector3(x,0,z), Quaternion.identity);
        }

    }
}
 