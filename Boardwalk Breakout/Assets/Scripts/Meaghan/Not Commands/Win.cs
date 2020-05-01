using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject win;
    public GameObject wintext;
    public GameObject button;
    public bool isWin { get; private set; }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isWin = true;
            win.SetActive(true);
            wintext.SetActive(true);
            button.SetActive(true);
        }
    }
}
