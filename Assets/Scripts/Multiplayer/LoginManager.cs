using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginManager : MonoBehaviour
{

    public TMP_InputField PlayerName_InputName;


    public void ConnectAnonymously()
    {
        ConnectUsingSettings();
    }

    public void ConnectToNetServer()
    {
        if(PlayerName_InputName != null)
        {
            NickName = PlayerName_InputName.text;
            ConnectUsingSettings();
        }
    }

    public void ConnectUsingSettings()
    {
        GetStandartSettings();
    }

    void GetStandartSettings()
    {

    }

    public override void OnConnected()
    {
        Debug.Log("OnConnected is called. The server is available!");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master Server with player name: " + NickName);
        LoadLevel("HomeScene");
    }


}
