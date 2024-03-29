using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouv : MonoBehaviour
{
    public float MoveSpeed = 5.0f;
    public float RotationSpeed = 120.0f;
    public GameObject[] roueGauche;
    public GameObject[] roueDroite;

    public float RoueRotationSpeed = 200.0f;

    private Rigidbody rb;
    private float MoveInputs;
    private float RotationInputs;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        MoveInputs = Input.GetAxis("Vertical");
        RotationInputs = Input.GetAxis("Horizontal");

        RotationRoues(MoveInputs, RotationInputs);
    }
    void FixedUpdate()
    {
        MoveTankObg(MoveInputs);
        RotateTank(RotationInputs);
    
    }

    void MoveTankObg(float input)
    {
        Vector3 MoveDirection = transform.forward * input * MoveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + MoveDirection);
    }
    void RotateTank(float input)
    {
        float Rotation = input * RotationSpeed * Time.fixedDeltaTime;
        Quaternion TurnRotation = Quaternion.Euler(0.0f, Rotation, 0.0f);
        rb.MoveRotation(rb.rotation * TurnRotation);
    }
    void RotationRoues(float MoveInputs, float RotationInputs)
    {
        float RoueRotation = MoveInputs * RoueRotationSpeed * Time.fixedDeltaTime;
        foreach (GameObject roue in roueGauche)
        {
            if (roue != null)
            {
                roue.transform.Rotate(RoueRotation - RotationInputs * RoueRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
       
        foreach (GameObject roue in roueDroite)
        {
            if (roue != null)
            {
                roue.transform.Rotate(RoueRotation + RotationInputs * RoueRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }
}
