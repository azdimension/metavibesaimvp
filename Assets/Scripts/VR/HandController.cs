using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandController : MonoBehaviour
{
    ActionBasedController controller;

    public Hand hand;

    void Start()
    {
        controller = GetComponent<ActionBasedController>();
    }

    
    void Update()
    {
        hand.SetGrip(controller.selectAction.action.ReadValue<float>());
        hand.SetTrigger(controller.activateAction.action.ReadValue<float>());

        //Debug.Log("Grip data:" + controller.selectAction.action.ReadValue<float>());
        //Debug.Log("Trigger data:" + controller.activateAction.action.ReadValue<float>());
    }

}
