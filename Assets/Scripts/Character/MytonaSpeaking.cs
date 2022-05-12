using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MytonaSpeaking : MonoBehaviour
{

    AudioSource myAudio;
    Animator MyAnimator;

    public float StartDelayTime = 2f;
    
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        MyAnimator = GetComponent<Animator>();
        Invoke("StartAudio", StartDelayTime);
    }

    void StartAudio()
    {
        myAudio.Play();
        float playSoundTime = myAudio.clip.length + 0.5f;
        MyAnimator.SetBool("IsTalking", true);
        Invoke("AudioFinished", playSoundTime);
    }

    void AudioFinished()
    {
        MyAnimator.SetBool("IsTalking", false);
    }

}
