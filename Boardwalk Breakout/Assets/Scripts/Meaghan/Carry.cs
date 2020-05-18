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
    private bool carrying;
    private bool dropped;

    private void Start()
    {
        carryRB = objectCarried.GetComponent<Rigidbody>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plushie" && other.GetComponent<FollowCommand>().goCarry && !carrying)
            plushies.Add(other.gameObject);

        if (other.tag == "Ground" && dropped)
        {
            objectCarried.transform.rotation = Quaternion.identity;
            objectCarried.transform.position = new Vector3(objectCarried.transform.position.x, objectCarried.transform.lossyScale.y / 2, objectCarried.transform.position.z);
            objectCarried.GetComponent<Rigidbody>().isKinematic = true;
            dropped = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Plushie") && !carrying)
        {            plushies.Remove(other.gameObject);
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
                plushies[i].transform.SetParent(null);
                plushies[i].GetComponent<Rigidbody>().isKinematic = false;
                plushies[i].GetComponent<NavMeshAgent>().enabled = true;
                plushies.RemoveAt(i);
            }
            objectCarried.transform.SetParent(null);
            carrying = false;
            dropped = true;
        }
        else if (plushies.Count >= numPlushReq && !carrying)
        {
            firstPlushie = plushies[0];
            plushieRB = firstPlushie.GetComponent<Rigidbody>();
            for (int i = 1; i <= plushies.Count - 1; i++)
            {
                plushies[i].GetComponent<Rigidbody>().isKinematic = true;
                plushies[i].transform.SetParent(firstPlushie.transform);
                plushies[i].GetComponent<NavMeshAgent>().enabled = false;
            }
            objectCarried.transform.position = plushieRB.position + new Vector3(0, firstPlushie.transform.lossyScale.y * 2.3f, 0);
            objectCarried.transform.SetParent(plushieRB.transform);
            firstPlushie.GetComponent<FollowCommand>().setAllTasksFalse();
            
            carrying = true;
        }
    }
}