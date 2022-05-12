using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomManager : MonoBehaviour
{

    private string mapType;

    void Start()
    {
        Network.AutomaticallySyncScene = true;

        if(!Network.IsConnectedAndReady)
        {
            Network.ConnectUsingSettings();
        }
        else
        {
            Network.JoinLobby();
        }
    }


    public void JoinRandomRoom()
    {
        Network.JoinRandomRoom();
    }

    public void OnEnterButtonClicked_Outdoor()
    {

    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to servers again.");
        Network.JoinLobby();
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("A room is created with the name: " + Network.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
     

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + "Player count: " + Network.CurrentRoom.PlayerCount);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if(roomList.Count == 0)
        {

        }

        foreach(RoomInfo room in roomList)
        {
            Debug.Log(room.Name);
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined the lobby");
    }

    private void CreateAndJoinRoom()
    {
        string randomRoomName = "Room_" + mapType + Random.Range(0, 1000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 20;

        roomOptions.CustomRoomPropertiesForLobby = roomPropsInLobby;
        roomOptions.CustomRoomProperties = customRoomProperties;

        Network.CreateRoom(randomRoomName, roomOptions);
    }

}
