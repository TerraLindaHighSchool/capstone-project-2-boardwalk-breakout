using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowCommand : MonoBehaviour
{
    public bool goPush { get; private set; }
    public bool goPull { get; private set; }
    public bool goStack { get; private set; }
    public bool goCarry { get; private set; }
    public bool goWait { get; private set; }
    public bool playerWait { get; set; }


    public static GameObject targetObj { get; set; }
    public static GameObject player { get; set; }
    public static bool hasTarget { get; set; }


    private NavMeshAgent nav;
    private Animator anim;


    //****temporary object to replace selection****

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nav.enabled)
        {
            if (!doingTask())
            {
                if (goWait || playerWait)
                    Wait();
                else
                    Follow();
            }
            else
            {
                nav.SetDestination(targetObj.transform.position);
            }
        }
    }

    public void Follow()
    {
        nav.isStopped = false;
        anim.SetBool("isWalking", true);
        nav.SetDestination(player.transform.position);
    }

    private void Wait()
    {
        nav.velocity = Vector3.zero;
        nav.isStopped = true;
        anim.SetBool("isWalking", false);
    }


    public bool doingTask()
    {
        if (Input.GetKey(KeyCode.Tab)) //FOLLOW
        {
            setAllTasksFalse();
            targetObj = null;
            return hasTarget = false;
        }
        else if ((Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3))) //WAIT
        {
            nav.isStopped = true;
            goWait = true;
            return false;
        }
        else if (hasTarget) //does not do action unless player has touched an object
        {
            if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))) //PUSH
            {
                anim.SetBool("isWalking", true);
                nav.isStopped = false;
                setAllTasksFalse();
                goPush = true;
            }

            if ((Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2))) //CARRY
            {
                anim.SetBool("isWalking", true);
                nav.isStopped = false;
                setAllTasksFalse();
                goCarry = true;
            }
        }

        return (goPush || goCarry); //only two conditions where doingTask is true
    }

    public void setAllTasksFalse()
    {
        goPush = false;
        goPull = false;
        goStack = false;
        goCarry = false;
        goWait = false;
    }
}


