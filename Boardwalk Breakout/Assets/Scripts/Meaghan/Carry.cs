using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Carry : MonoBehaviour
{
    public int numPlushReq;
    public GameObject objectCarried;

    private List<GameObject> plushies = new List<GameObject>();
    private Rigidbody carryRB;
    private Rigidbody plushieRB;
    private GameObject firstPlushie;

    private void Start()
    {
        carryRB = objectCarried.GetComponent<Rigidbody>();
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
        if (other.gameObject.tag.Equals("Plushie"))
        {
            plushies.Remove(other.gameObject);
            if (plushies.Count == 0)
            {
                firstPlushie = null;
                plushieRB = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            objectCarried.GetComponent<Rigidbody>().isKinematic = false;
            for (int i = 0; i <= plushies.Count - 1; i++)
            {
                plushies[i].GetComponent<FollowCommand>().setAllTasksFalse();
                plushies.RemoveAt(i);
            }
            objectCarried.transform.parent = null;
            objectCarried.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if (plushies.Count >= numPlushReq)
        {
            firstPlushie = plushies[0];
            plushieRB = firstPlushie.GetComponent<Rigidbody>();
            carryRB.position = plushieRB.position + new Vector3(0, firstPlushie.transform.lossyScale.y * 1.5f, 0);
            objectCarried.transform.parent = firstPlushie.transform;
            firstPlushie.GetComponent<FollowCommand>().setAllTasksFalse();
            for (int i = 1; i <= plushies.Count; i++)
            {
                plushies[i].GetComponent<NavMeshAgent>().stoppingDistance = 3f;
                plushies[i].GetComponent<NavMeshAgent>().SetDestination(firstPlushie.transform.position);
            }
        }
    }
}