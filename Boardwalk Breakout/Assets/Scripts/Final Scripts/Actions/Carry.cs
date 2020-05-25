using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.AI;

public class Carry : MonoBehaviour
{
    public int numPlushReq;
    
    private List<GameObject> plushies = new List<GameObject>();
    private Rigidbody carryRB;
    private Rigidbody plushieRB;
    private GameObject firstPlushie;
    private bool carrying;
    //private bool dropped;

    public GameObject warningUI;

    private void Start()
    {
        carryRB = GetComponent<Rigidbody>();
       
    }

    private void OnTriggerEnter(Collider other)
    {

        if((other.tag == "Player") && (plushies.Count < numPlushReq))
        {
            warningUI.SetActive(true);
        }
        /*if(plushies.Count < numPlushReq)
        {   
            warningUI.SetActive(true);
            
            
        }*/

        if ((other.tag == "Plushie" && other.GetComponent<FollowCommand>().goCarry /*|| (other.tag == "Player" && !other.isTrigger))*/ && !carrying))
        {
            plushies.Add(other.gameObject);
            //if (other.tag == "Player" && !other.isTrigger)
               // firstPlushie = other.gameObject;
        }

        /*if (other.tag == "Ground" && dropped)
        {
            transform.rotation = Quaternion.identity;
            GetComponent<Rigidbody>().isKinematic = true;
            dropped = false;
        }*/
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Plushie" && other.GetComponent<FollowCommand>().goCarry /*|| (other.tag == "Player" && !other.isTrigger))*/ && !carrying))
        {            plushies.Remove(other.gameObject);
            if (plushies.Count == 0)
            {
                firstPlushie = null;
                plushieRB = null;
            }
        }

        if ((other.tag == "Player") && (plushies.Count < numPlushReq))
        {
            warningUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
            stopCarry();
        if (carrying)
        {
            for (int i = 1; i <= plushies.Count - 1; i++)
                plushies[i].GetComponent<FollowCommand>().playerWait = firstPlushie.GetComponent<FollowCommand>().playerWait; //wait when first plushie waits
        }
        else if (plushies.Count >= numPlushReq)
        {

            GetComponent<Rigidbody>().isKinematic = true;
            //if(!(firstPlushie.tag == "Player"))
            firstPlushie = plushies[0];
            plushieRB = firstPlushie.GetComponent<Rigidbody>();
            for (int i = 1; i <= plushies.Count - 1; i++)
            {
                plushies[i].transform.SetParent(firstPlushie.transform);
                plushies[i].GetComponent<NavMeshAgent>().enabled = false;
                plushies[i].GetComponent<FollowCommand>().setAllTasksFalse();
            }
            transform.position = plushieRB.position + new Vector3(0, firstPlushie.transform.lossyScale.y * 1.2f, 0);
            transform.rotation = Quaternion.identity;
            transform.SetParent(plushieRB.transform);
            firstPlushie.GetComponent<FollowCommand>().setAllTasksFalse();

            carrying = true;
        }

        
        
    }

    public void stopCarry()
    {
        FollowCommand.hasTarget = false;
        FollowCommand.targetObj = null;
        GetComponent<Rigidbody>().isKinematic = false;
        for (int i = plushies.Count-1; i >= 0; i--)
        {
            plushies[i].transform.SetParent(null);
            plushies[i].GetComponent<NavMeshAgent>().enabled = true;
            plushies.RemoveAt(i);
            plushies[i].GetComponent<FollowCommand>().playerWait = false;
        }
        transform.SetParent(null);
        carrying = false;
        //dropped = true;
    }
}