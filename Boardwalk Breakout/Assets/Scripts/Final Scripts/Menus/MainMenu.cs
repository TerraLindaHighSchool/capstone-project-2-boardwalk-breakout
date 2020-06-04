using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource confirm;
    public AudioSource menuSound;
    //public GameObject loseUI;

    void Start()
    {
       confirm.GetComponent<AudioSource>();
       menuSound.GetComponent<AudioSource>();
    }

    //Start Game
    public void startGame()
    {
        confirm.Play();
        Application.LoadLevel(1);
        //SceneManager.LoadScene(1);
        //loseUI.SetActive(false);

    }

    //How To Play Page
    public void howToPlayGame()
    {
       menuSound.Play();
       SceneManager.LoadScene("How To Play");
    }

    //Credit Page
    public void credits()
    {
        menuSound.Play();
        SceneManager.LoadScene("Credit Page");
    }

    //Exit Game
    public void exitGame()
    {
        confirm.Play();
        Application.Quit(); 
    }
}
