using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonController : MonoBehaviour
{

    public InputActionReference triggerAction;
    public GameObject PauseMenu;
    public GameObject LoadingText;

    // Start is called before the first frame update
    void Start()
    {
        triggerAction.action.performed += _ => Fire();
        triggerAction.action.Enable();

        PauseMenu.SetActive(false);

        Invoke("HideLoadingText", 2f);
    }

    void HideLoadingText()
    {
        LoadingText.SetActive(false);
    }

    void Fire()
    {
        Debug.Log("Fire has worked!");
        PauseMenu.SetActive(true);
    }

    public void DeactivatePauseMenu()
    {
        PauseMenu.SetActive(false);
    }


}
