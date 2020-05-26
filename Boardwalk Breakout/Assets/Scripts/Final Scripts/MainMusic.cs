using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusic : MonoBehaviour
{
    public AudioSource introMusic;
    public AudioSource mainMusic;

    // Start is called before the first frame update
    void Start()
    {
        introMusic.Play();
        mainMusic.Play();
    }

    
}
