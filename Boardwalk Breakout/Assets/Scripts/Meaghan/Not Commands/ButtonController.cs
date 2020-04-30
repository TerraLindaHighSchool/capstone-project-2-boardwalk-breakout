using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    /*
     * Plushies MUST have the plushie tag. To create a button, create a cylinder w/ rigidbody. Duplicate it. Uncheck mesh renderer, add mess collider. Turn on is convex and is trigger.
     * Move it by pressing V to align it exactly ontop the cylinder. Add the script. In the inspector, enter the number of bears required to use the button in numPlushReq (number of plushies
     * required).
     * 
     * Door MUST be a child of a cylindrical hinge.
     */


    public GameObject hinge;
    private bool pressed;
    public int numPlushReq;
    private int numPlush = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plushie")
        {
            pressed = true;
            numPlush++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plushie")
        {
            pressed = false;
            numPlush--;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed && numPlush == numPlushReq)
        {
            hinge.transform.localRotation = Quaternion.Slerp(hinge.transform.localRotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 2);
        }
    }
}
