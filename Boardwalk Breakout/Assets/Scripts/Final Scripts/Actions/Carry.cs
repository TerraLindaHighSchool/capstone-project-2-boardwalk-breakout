using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.AI;

public class Carry : MonoBehaviour
{
    public int numPlushReq;
    public static GameObject player { get; set; }

    private List<GameObject> plushies = new List<GameObject>();
    private Rigidbody carryRB;
    private Rigidbody plushieRB;
    private GameObject firstPlushie;
    public bool carrying { get; set; }

    //private bool dropped;

    public bool wrong;

    public GameObject notEnoughPlushiesUI;
    public GameObject youNoDoUI;

    //public int counterForPlushies = 0;

    private void Start()
    {
        carryRB = GetComponent<Rigidbody>();
        /*GameObject thePlayer = GameObject.Find("Main Player");
        PlayerController plushieCounter = thePlayer.GetComponent<PlayerController>();
        counterForPlushies = plushieCounter.count;*/
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plushie" && !carrying)
        {
            if (other.GetComponent<FollowCommand>().goCarry)
            {
                if ((other.tag == "Player") && (plushies.Count < numPlushReq))
                {
                   notEnoughPlushiesUI.SetActive(true);   
                }
                else
                    plushies.Add(other.gameObject);
            }

            if (other.GetComponent<FollowCommand>().goPush)
            {
                youNoDoUI.SetActive(true);
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if ((other.tag == "Plushie" && !carrying))
        {
            if(other)
            plushies.Remove(other.gameObject);
            if (plushies.Count == 0)
            {
                firstPlushie = null;
                plushieRB = null;
            }
            if (!wrong)
            {
                notEnoughPlushiesUI.SetActive(false);
                youNoDoUI.SetActive(false);
            }
        }
    }

  

    // Update is called once per frame
    void Update()
    {
        if (carrying && Input.GetKey(KeyCode.Tab))
        {
            stopCarry();
        }
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
            firstPlushie.GetComponent<FollowCommand>().setAllTasksFalse();
            for (int i = 1; i <= plushies.Count - 1; i++)
            {
                plushies[i].transform.SetParent(firstPlushie.transform);
                plushies[i].GetComponent<NavMeshAgent>().enabled = false;
                plushies[i].GetComponent<FollowCommand>().setAllTasksFalse();


            }
            transform.position = plushieRB.position + new Vector3(0, firstPlushie.transform.lossyScale.y * 1.2f, 0);
            transform.rotation = Quaternion.identity;
            transform.SetParent(plushieRB.transform);

            carrying = true;
        }
    }

    public void stopCarry()
    {
        FollowCommand.hasTarget = false;
        FollowCommand.targetObj = null;
        for (int i = plushies.Count-1; i >= 0; i--)
        {
            plushies[i].transform.SetParent(null);
            plushies[i].GetComponent<NavMeshAgent>().enabled = true;
            plushies.RemoveAt(i);
            plushies[i].GetComponent<FollowCommand>().playerWait = false;
        }
            GetComponent<Rigidbody>().isKinematic = false;
            transform.SetParent(null);
            carrying = false;
        //dropped = true;
    }
}

/*
 *
 *
 *    if (other.tag == "Plushie" && !carrying)
        {
            if (other.GetComponent<FollowCommand>().goCarry)
            {
                if ((other.tag == "Player") && (plushies.Count < numPlushReq))
                {
                    Debug.Log("It's touching but not enough plushies");
                   notEnoughPlushiesUI.SetActive(true);   
                }
                else
                    plushies.Add(other.gameObject);
            }
            else if (other.GetComponent<FollowCommand>().goPush)
            {
                youNoDoUI.SetActive(true);
                Debug.Log("SET ACTIVE You cannot push this object, you imbecile. Try something else.");
            }
        }
 */
