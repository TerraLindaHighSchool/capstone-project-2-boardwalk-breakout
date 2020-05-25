using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public GameObject loseUI;
    public float inventory = 3;

    // Update is called once per frame
    void Update()
    {
        if (inventory == inventory - 1)
        {
            loseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
