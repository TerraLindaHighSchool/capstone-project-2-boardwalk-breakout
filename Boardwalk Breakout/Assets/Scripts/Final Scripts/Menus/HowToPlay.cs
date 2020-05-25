using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public AudioSource confirm;
    public AudioSource menuSound;

    void Start()
    {
       confirm.GetComponent<AudioSource>();
       menuSound.GetComponent<AudioSource>();
        menuSound.Play();
        
    }

    public void returnToMenu()
    {
        confirm.Play();
        SceneManager.LoadScene(0);
        
    }
}
