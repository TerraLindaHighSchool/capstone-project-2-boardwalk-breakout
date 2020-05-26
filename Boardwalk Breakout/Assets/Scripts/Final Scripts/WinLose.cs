using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public static GameObject player { get; set; }
    public int[] events;
    public static int currentEvent { get; set; } //each int represents its event's (in order) required plushies to complete
    /*
     * CURRENT EVENT INDEX
     *  #       Function                                                            Moving onto next event
     *  -1: game has started, player is collecting plushies that are "given' -> playercontroller currentevent++
     * 0+: player is doing tasks, lose if don't have required plushies -> "success" statement in each event ++currentEvent (ex: opening the door to a cage)
     * last event: number required to exit the level successfully
     */
    
    public static bool playerLost { get; set; } //activated by guard controller when player is caught

    public static bool initalPlushLose { get; set; }
    //if you lose any plushies while getting initial plushies, activated by guard.
    //this is required because if initial plushies is considered one of the events, the player will start out with less than required for the
    //initial plushies event and it will be instand game over

    private void Start()
    {
        currentEvent = -1;
    }
    void Update()
    {
        if (playerLost)
            playerLose();
        else
            numberLose();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !other.isTrigger && other.GetComponent<PlayerController>().count >= events[events.Length - 1])
            Debug.Log("You win, winner!");
    }

    private void numberLose()
    {
        if ((currentEvent != -1 && !player.GetComponent<PlayerController>().gettingInitial && player.GetComponent<PlayerController>().count < events[currentEvent]) || initalPlushLose)
            Debug.Log("You let too many plushies get captured, you idiot!");
    }

    public void playerLose()
    {
        Debug.Log("You got captured, you idiot!");
    }
}
    
