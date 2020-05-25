using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public GameObject player;
    public GameObject gameEndingUI;
    public float plushieInventory = 3;

    bool isPlayerAtExit;

    void OnTriggerEnter(Collider other)
    {
        if (plushieInventory == 3)
        {
            if (other.gameObject == player)
            {
                isPlayerAtExit = true;
            }
        }
    }

    void Update()
    {
        if (isPlayerAtExit)
        {
            endLevel();
        }    
    }

    void endLevel()
    {
        gameEndingUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void playAgain()
    {
        SceneManager.LoadScene(1);
    }

}
