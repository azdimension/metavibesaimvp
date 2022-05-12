using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlanetMovement : MonoBehaviour
{
    [Header("Static Planet Rotation")]
    public float MinZRotation = 1f;
    public float MaxZRotation = 1f;
    float stadartZRotation;

    [Header("Movement Control")]
    public float LerpSpeed = 1f;
    public Transform FinalGoal;

    [Header("Dynamic Planet Rotation")]
    public float rotationSpeed = 4f;

    bool isRotating;
    bool isNearPlayer;
    Vector2 ControllerRotation;


    [Header("Controls")]
    public List<ActionBasedController> ActionControllers;
    public InputActionReference MyAction = null;

    private void Start()
    {
        isRotating = true;
        isNearPlayer = false;

        stadartZRotation = Random.Range(MinZRotation, MaxZRotation);

        ControllerRotation = new Vector2(0.0f, 0.0f);
    }

    

    void FixedUpdate()
    {
        if(isRotating)
        {
            transform.Rotate(new Vector3(0f, 0f, stadartZRotation) * Time.deltaTime);
        }

        if (MyAction != null)
        {
            ControllerRotation = MyAction.action.ReadValue<Vector2>();
            //Debug.Log("My float:" + MyAction.action.ReadValue<Vector2>());
        }


        if(isNearPlayer)
        {
            RotateInVR();

        }




        //ActionBasedController actionbased;
        //public List<ActionBasedController> ActionControllers;
        //XRBaseController controllerbase;
        /*
        foreach (XRController xRController in controllers)
        {
            if (xRController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 positionVector))
            {
                if (positionVector.magnitude > 0.20f)
                {
                    Debug.Log(positionVector);
                }
            }
        }*/


    }



    void RotateInVR()
    {
        if (ControllerRotation.x < 0.1f && ControllerRotation.y > 0.5f)
        {
            Debug.Log("UP!");
            RotatePlanetByParameters(ControllerRotation.x, ControllerRotation.y);
        }
        else if(ControllerRotation.x < 0.1f && ControllerRotation.y < -0.5f)
        {
            Debug.Log("DOWN!");
            RotatePlanetByParameters(ControllerRotation.x, ControllerRotation.y);
        }
        else if (ControllerRotation.x > 0.5f && ControllerRotation.y < 0.1f)
        {
            Debug.Log("RIGHT!");
            RotatePlanetByParameters(ControllerRotation.x, ControllerRotation.y);
        }
        else if(ControllerRotation.x < -0.5f && ControllerRotation.y < 0.1f)
        {
            Debug.Log("LEFT!");
            RotatePlanetByParameters(ControllerRotation.x, ControllerRotation.y);
        }
        else
        {
            Debug.Log("NEUTRAL!");
        }
    }

    void RotatePlanetByParameters(float xvalue, float yvalue)
    {
        float XaxisRotation = xvalue * rotationSpeed;
        float YaxisRotation = yvalue * rotationSpeed;

        //transform.Rotate(Vector3.down, XaxisRotation);
        transform.Rotate(Vector3.up, XaxisRotation);
        transform.Rotate(Vector3.right, YaxisRotation);
    }

    void RotateObject()
    {
        float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
        float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(Vector3.down, XaxisRotation);
        transform.Rotate(Vector3.right, YaxisRotation);
    }

    public void MoveToNearestPosition()
    {
        StartCoroutine(SmoothLerp(LerpSpeed));
    }

    private IEnumerator SmoothLerp(float time)
    {
        Vector3 startingPos = transform.position;
        Vector3 finalPos = FinalGoal.position;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;

        }
        PlanetApproached();
    }

    public void PlanetApproached()
    {
        isRotating = false;
        isNearPlayer = true;
    }
}
