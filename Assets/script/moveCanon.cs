using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class moveCanon : MonoBehaviour
{
    public float mouseMove;
    public LayerMask ground;
    private Transform body;

    private void Start()
    {
       
        body = GetComponent<Transform>();
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, ground))
        {
            //transform.position = hitInfo.point; 
            transform.LookAt(hitInfo.point);
            //transform.rotation = new UnityEngine.Quaternion(0, transform.rotation.y, 0, 1);


        }

    }
    public void Tourner(InputAction.CallbackContext context)
    {
       //mousePos = context.ReadValue<Vector3>();
        //mouseMove = Vector3.Angle(mousePos, );
    }
}
