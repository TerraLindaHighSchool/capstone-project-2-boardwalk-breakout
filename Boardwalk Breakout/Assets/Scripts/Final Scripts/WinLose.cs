using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public static GameObject player { get; set; }
    public int[] events;
    public static float currentEvent { get; set; } //each int represents its event's (in order) required plushies to complete
    /*
     * CURRENT EVENT INDEX
     *  #       Function                                                            Moving onto next event
     *  -1: game has started, player is collecting plushies that are "given' -> playercontroller currentevent++
     * 0+: player is doing tasks, lose if don't have required plushies -> "success" statement in each event ++currentEvent (ex: opening the door to a cage)
     * last event: number required to exit the level successfully
     */
    
    public static bool playerLost { get; set; } //activated by guard controller when player is caught
    public static bool numLose { get; set; }


    public GameObject winUI;
    public GameObject loseUI;

    private void Start()
    {
        currentEvent = -1;
        winUI.SetActive(false);
        loseUI.SetActive(false);
    }
    void Update()
    {
        if (playerLost)
        {
            playerLose();
        }
        else
            numberLose();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentEvent == events.Length -1 && other.tag == "Player" && !other.isTrigger && other.GetComponent<PlayerController>().count >= events[events.Length - 1])
            winUI.SetActive(true);
            //Time.timeScale = 0f;
            //Debug.Log("You win, winner!");
    }

    private void numberLose()
    {
        if ((!(currentEvent < 0) && player.GetComponent<PlayerController>().count < events[(int) currentEvent]) || numLose)
            loseUI.SetActive(true);
          
            
            //Debug.Log("You let too many plushies get captured, you idiot!");
    }

    public void playerLose()
    {
        loseUI.SetActive(true);

        Debug.Log("You got captured, you idiot!");
    }

    /*IEnumerator uiStart()
    {
        yield return new WaitForSeconds(2);
        loseUI.SetActive(false);
        SceneManager.LoadScene("Menu");

    }*/
}
    
