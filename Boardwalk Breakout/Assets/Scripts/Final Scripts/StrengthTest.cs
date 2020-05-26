using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthTest : MonoBehaviour
{

    public GameObject doorHinge;
    public GameObject[] plushies;

    private bool open;
    bool stoppedCarry;
    private GameObject mallet;

    // Update is called once per frame
    void Update()
    {
        if (open)
            Open();
        else
            Stay();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mallet")
        {
            open = true;
            mallet = other.gameObject;
            mallet.GetComponent<Carry>().enabled = false;
        }
    }

    private void Open()
    {
        doorHinge.transform.localRotation = Quaternion.Slerp(doorHinge.transform.localRotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 2);
        if (!stoppedCarry)
        {
            mallet.GetComponent<Carry>().stopCarry();
            stoppedCarry = true;
        }
        WinLose.currentEvent++;
    }

    private void Stay()
    {
        foreach (GameObject plushie in plushies)
            plushie.GetComponent<FollowCommand>().enabled = false;
    }
}
