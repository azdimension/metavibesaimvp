using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementController : MonoBehaviour
{

    public float speed = 1.0f;

    public InputActionReference MyAction = null;

    public GameObject head = null;

    Vector2 MovementVector;

    private void Start()
    {
        MovementVector = new Vector2(0.0f, 0.0f);
    }

    private void FixedUpdate()
    {
        if (MyAction != null)
        {
            MovementVector = MyAction.action.ReadValue<Vector2>();
            Move(MovementVector);

        }
    }

    private void Move(Vector2 positionVector)
    {
        // Apply the touch position to the head's forward Vector
        Vector3 direction = new Vector3(positionVector.x, 0, positionVector.y);
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);

        // Rotate the input direction by the horizontal head rotation
        direction = Quaternion.Euler(headRotation) * direction;

        // Apply speed and move
        Vector3 movement = direction * speed;
        transform.position += (Vector3.ProjectOnPlane(Time.deltaTime * movement, Vector3.up));

    }

}
