using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthTest : MonoBehaviour
{
    
    public GameObject doorHinge;

    private bool open;
    private GameObject mallet;

    // Update is called once per frame
    void Update()
    {
        if (open)
            Open();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mallet")
        {
            open = true;
            mallet = other.gameObject;
        }
    }

    private void Open()
    {
        doorHinge.transform.localRotation = Quaternion.Slerp(doorHinge.transform.localRotation, Quaternion.Euler(0, 90, 0), Time.deltaTime* 2);
        mallet.GetComponent<Carry>().stopCarry();
    }
}
