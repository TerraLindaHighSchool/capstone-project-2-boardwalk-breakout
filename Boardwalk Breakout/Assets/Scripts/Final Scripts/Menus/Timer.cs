using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 10f;
    string time;

    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;    
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
         
       //countdownText.text = currentTime;
    }
}
