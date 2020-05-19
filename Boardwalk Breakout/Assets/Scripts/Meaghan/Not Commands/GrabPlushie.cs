using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPlushie : MonoBehaviour
{

    public GameObject plushie;
    public static GameObject player;
    //public GameObject game;
    //public GameObject button;
    public bool isDead { get; private set; }
    private int plushCaptured = 0;
    public int extraPlush;

    private void OnTriggerEnter(Collider collision)
    {
        //if (!GameObject.Find("Beam").GetComponent<GrabPlushie>().isDead && !GameObject.Find("Exit").GetComponent<Win>().isWin)
        //{
            if (collision.gameObject.tag == "Plushie")
            {
                Destroy(collision.gameObject);
                plushCaptured++;
                if (plushCaptured > extraPlush)
                {
                    //game.SetActive(true);
                    plushie.SetActive(true);
                    //button.SetActive(true);
                }
            }

            if (collision.gameObject.tag == "Player")
            {
                //game.SetActive(true);
                player.SetActive(true);
                //button.SetActive(true);
                isDead = true;
            }
        //}
    }

}

