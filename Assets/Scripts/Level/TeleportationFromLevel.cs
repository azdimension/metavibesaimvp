using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeleportationFromLevel : MonoBehaviour
{

    public UnityEvent m_LevelQuitEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LaunchOtherLevel();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LaunchOtherLevel();
        }
    }

    void LaunchOtherLevel()
    {
        if (m_LevelQuitEvent != null)
        {
            m_LevelQuitEvent.Invoke();
        }

        gameObject.SetActive(false);

    }


}
