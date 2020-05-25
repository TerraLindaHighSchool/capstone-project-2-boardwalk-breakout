using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource confirm;
    public AudioSource menuSound;

    void Start()
    {
       confirm.GetComponent<AudioSource>();
       menuSound.GetComponent<AudioSource>();
    }

    public void startGame()
    {
        confirm.Play();
        SceneManager.LoadScene(1);
    }

    public void howToPlayGame()
    {
       menuSound.Play();
       SceneManager.LoadScene(2);
    }

    public void exitGame()
    {
        confirm.Play();
        Application.Quit(); 
    } 
}
