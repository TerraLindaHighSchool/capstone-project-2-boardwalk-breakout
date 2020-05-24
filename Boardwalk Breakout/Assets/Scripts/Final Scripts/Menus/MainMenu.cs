using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void howToPlayGame()
    {
       SceneManager.LoadScene(2);
    }

    public void exitGame()
    {
        Application.Quit(); 
    } 
}
