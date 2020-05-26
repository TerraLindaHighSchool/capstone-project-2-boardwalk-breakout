using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public static GameObject player { get; set; }
    public int[] events;
    public static int currentEvent { get; set; }

    private void Start()
    {
        currentEvent = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberLose())
            Debug.Log("sup");
    }

    private bool numberLose()
    {
        if (currentEvent != -1 && player.GetComponent<PlayerController>().count != 0 && player.GetComponent<PlayerController>().count < events[currentEvent])
            return true;
        else
            return false;
    }
}
