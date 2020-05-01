using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : MonoBehaviour
{
    public int numPlushReq;
    public GameObject objectCarried;

    private Rigidbody carryRB;
    private Rigidbody plushieRB;
    private int numPlush;
    private GameObject firstPlushie;

    private void Start()
    {
        carryRB = objectCarried.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plushie")
        {
            if (numPlush == 0)
            {
                firstPlushie = other.gameObject;
                plushieRB = other.GetComponent<Rigidbody>();
            }
            numPlush++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plushie")
        {
            numPlush--;
            if (numPlush == 0)
            {
                firstPlushie = null;
                plushieRB = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numPlush >= numPlushReq)
        {
            carryRB.position = plushieRB.position + new Vector3(0, firstPlushie.transform.lossyScale.y * 1.5f, 0);
            objectCarried.transform.parent = firstPlushie.transform;
        }
    }
}
