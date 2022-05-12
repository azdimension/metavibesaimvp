using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class GetUser : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetCurrentUser());
    }

    IEnumerator GetCurrentUser()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://metavibes.ai");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            //byte[] results = Metavibes Data
        }
    }
}