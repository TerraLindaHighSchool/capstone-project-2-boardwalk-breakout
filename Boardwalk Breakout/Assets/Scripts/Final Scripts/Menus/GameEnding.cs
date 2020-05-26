using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
 
    public GameObject winUI;
    public GameObject loseUI;

    public void playAgain()
    {
        winUI.SetActive(false);
        loseUI.SetActive(false);
        SceneManager.LoadScene(1);
        //Application.LoadLevel(Application.loadedLevel);
        //Time.timeScale = 1f;
    }


}
