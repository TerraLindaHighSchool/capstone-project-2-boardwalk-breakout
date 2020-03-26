using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenController : MonoBehaviour
{
    /*
     * Plushies MUST have the plushie tag. To create a button, create a cylinder w/ rigidbody. Duplicate it. Uncheck mesh renderer, add mess collider. Turn on is convex and is trigger.
     * Move it by pressing V to align it exactly ontop the cylinder. Add the script. In the inspector, enter the number of bears required to use the button in numPlushReq (number of plushies
     * required).
     * 
     * Door MUST be a child of a cylindrical hinge.
     */


    public GameObject hinge;
    private bool open;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Guard")
        {
            open = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Guard")
        {
            open = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            hinge.transform.localRotation = Quaternion.Slerp(hinge.transform.localRotation, Quaternion.Euler(0, 90, 0), Time.deltaTime * 2);
        }
        if(!open)
        {
            hinge.transform.localRotation = Quaternion.Slerp(hinge.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 2);
        }
    }
}
