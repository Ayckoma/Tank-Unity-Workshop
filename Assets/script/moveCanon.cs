using UnityEngine;
using UnityEngine.InputSystem;

public class moveCanon : MonoBehaviour
{
    public LayerMask ground;
    public float smoothSpeed = 15f;
    public float turnSpeed = 40f;
    private Vector2 _inputTurn;


    private void Update()
    {

        if(Input.mousePositionDelta.magnitude > 0f)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.y - transform.position.y;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            targetPosition.y = transform.position.y;

            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
        }
        else
        {
            if(_inputTurn.magnitude > 0f)
            {
                Vector3 targetPosition = transform.position + new Vector3(_inputTurn.x, 0, _inputTurn.y);
                Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position, Vector3.up);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed * Time.deltaTime);
            }
        }
    }
    
    public void tourner(InputAction.CallbackContext context)
    {
        _inputTurn =  context.ReadValue<Vector2>();
    }
}

/*public void Tourner(InputAction.CallbackContext context)
{

    float Rotation = input * smoothSpeed * Time.fixedDeltaTime;
    Quaternion TurnRotation = Quaternion.Euler(0.0f, Rotation, 0.0f);
    rb.MoveRotation(rb.rotation * TurnRotation);
    //mousePos = context.ReadValue<Vector3>();
    //mouseMove = Vector3.Angle(mousePos, );
}
}*/




/*using System.Collections;
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
            transform.LookAt(hitInfo.point);
        }

    }

}*/
