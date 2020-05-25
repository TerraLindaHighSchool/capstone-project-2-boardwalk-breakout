using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    public GameObject notEnoughPlushieUI;

    public void notEnoughPlushiesWarning()
    {
        notEnoughPlushieUI.SetActive(true);
        
    }
}
