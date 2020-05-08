using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : MonoBehaviour
{
    public int numPlushReq;
    public GameObject objectCarried;

    private List<GameObject> plushies = new List<GameObject>();
    private Rigidbody carryRB;
    private Rigidbody plushieRB;
    private GameObject firstPlushie;

    public bool moving { get; private set; }

    private void Start()
    {
        carryRB = objectCarried.GetComponent<Rigidbody>();
        moving = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plushie" && other.GetComponent<FollowCommand>().goCarry)
        {
            plushies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        plushies.Remove(other.gameObject);
        if (plushies.Count == 0)
        {
            firstPlushie = null;
            plushieRB = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (plushies.Count >= numPlushReq)
        {
            firstPlushie = plushies[0];
            plushieRB = firstPlushie.GetComponent<Rigidbody>();
            carryRB.position = plushieRB.position + new Vector3(0, firstPlushie.transform.lossyScale.y * 1.5f, 0);
            objectCarried.transform.parent = firstPlushie.transform;
            moving = false;
        }
        else
        {
            objectCarried.transform.parent = null;
            moving = false;
        }
    }
}
