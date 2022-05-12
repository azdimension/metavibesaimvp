using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Oculus;

public class GetName : MonoBehaviour
{

    public Text myText;

    // Start is called before the first frame update
    void Start()
    {

    }

    void GetUserName()
    {
        myText.text = Oculus.Platform.Users.GetLoggedInUser().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
