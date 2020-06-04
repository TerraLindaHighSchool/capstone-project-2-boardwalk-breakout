using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLose : MonoBehaviour
{
    public static GameObject player { get; set; }
    public int[] events;
    public static float currentEvent { get; set; } //each int represents its event's (in order) required plushies to complete

    private float eventReset = -1;
    public GameObject loseUI;
    public GameObject winUI;
    /*
     * CURRENT EVENT INDEX
     *  #       Function                                                            Moving onto next event
     *  -1: game has started, player is collecting plushies that are "given' -> playercontroller currentevent++
     * 0+: player is doing tasks, lose if don't have required plushies -> "success" statement in each event ++currentEvent (ex: opening the door to a cage)
     * last event: number required to exit the level successfully
     */

    public static bool playerLost { get; set; } //activated by guard controller when player is caught

    public void Start()
    {
        currentEvent = -1;
    }

    void Update()
    {
        loseUI.SetActive(false);
        if (playerLost)
        {
            playerLose();
        }
        else
            numberLose();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentEvent == events.Length - 1 && other.tag == "Player" && !other.isTrigger && other.GetComponent<PlayerController>().count >= events[events.Length - 1])
            winUI.SetActive(true);
    }

    private void numberLose()
    {
        if ((!(currentEvent < 0) && player.GetComponent<PlayerController>().count < events[(int)currentEvent]))
            loseUI.SetActive(true);
            
    }

    public void playerLose()
    {
        loseUI.SetActive(true); 
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
        {
          SceneManager.sceneLoaded -= OnLevelFinishedLoading;
        }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        eventReseting();
        playerLost = false;
        loseUI.SetActive(false);
        winUI.SetActive(false);
        Debug.Log(currentEvent);

    }

    void eventReseting()
    {
        currentEvent = eventReset;
    }
    
}
    
