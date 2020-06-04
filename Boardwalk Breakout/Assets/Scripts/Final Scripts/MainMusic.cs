using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class MainMusic : MonoBehaviour
{

    public AudioSource intro;
    public AudioSource mainM;
    private bool startedLoop;

    public AudioSource winningSound;
    public AudioSource losingSound;

    private bool endingPlaying;

    void Start()
    {
        endingPlaying = false;
        winningSound.GetComponent<AudioSource>();
        losingSound.GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if(!intro.isPlaying && !startedLoop)
        {
            mainM.GetComponent<AudioSource>().loop = true;
            mainM.Play();
            
            startedLoop = true;
        }

        if (WinLose.gameOverWin)
        {
            intro.Stop();
            mainM.Stop();

            if (endingPlaying == false)
            {
                winningSound.Play();
                endingPlaying = true;
            }
        }

        if (WinLose.gameOverLose)
        {
            intro.Stop();
            mainM.Stop();

            if(endingPlaying == false)
            {
                losingSound.Play();
                endingPlaying = true;
            }
        }


    }
}
