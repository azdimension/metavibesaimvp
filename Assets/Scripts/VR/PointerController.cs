using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PointerController : MonoBehaviour
{
    public XRController rightHand;
    public XRRayInteractor rightHandGrab;
    public InputHelpers.Button RightHandTriggerButton;

    public XRController leftHand;
    public XRRayInteractor leftHandGrab;
    public InputHelpers.Button LeftHandTriggerButton;

    bool HiddenHands;

    [SerializeField] List<GameObject> Hands;

    void Start()
    {
    }

    public void DeactivateHandGrabs()
    {
        HiddenHands = false;

        rightHandGrab.enabled = false;
        leftHandGrab.enabled = false;

        HideHandMeshes();
    }

    public void HideHandMeshes()
    {
        foreach (GameObject hand in Hands)
        {
            hand.SetActive(false);
        }

    }

    /*
    void Update()
    {

        if (HiddenHands)
        {
            bool rightpressed;
            rightHand.inputDevice.IsPressed(RightHandTriggerButton, out rightpressed);

            if (rightpressed)
            {
                rightHandGrab.enabled = true;
                leftHandGrab.enabled = false;
            }

            bool leftpressed;
            leftHand.inputDevice.IsPressed(LeftHandTriggerButton, out leftpressed);

            if (leftpressed)
            {
                rightHandGrab.enabled = false;
                leftHandGrab.enabled = true;
            }
        }

    }
    */
}
