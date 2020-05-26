using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class MainMusic : MonoBehaviour
{

    public AudioSource intro;
    public AudioSource mainM;
    private bool startedLoop;

    void FixedUpdate()
    {
        if(!intro.isPlaying && !startedLoop)
        {
            mainM.GetComponent<AudioSource>().loop = true;
            mainM.Play();
            
            startedLoop = true;
        }    
    }

}
