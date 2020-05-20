﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowCommand : MonoBehaviour
{
    public bool goWait { get; private set; }
    public bool goPush { get; private set; }
    public bool goPull { get; private set; }
    public bool goStack { get; private set; }
    public bool goCarry { get; private set; }

    
    public static GameObject targetObj { get; set; }
    public static GameObject player { get; set; }
    public static bool hasTarget { get; set; }


    [SerializeField] private float offset = 2.0f;
    private NavMeshAgent nav;

    Animator anim;
    public Animator playeranim;

    

    //****temporary object to replace selection****

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!doingTask())
        {
            Follow();
        }
        else
        {
            nav.stoppingDistance = 0;
            nav.SetDestination(targetObj.transform.position);
        }

    }

    private void Follow()
    {
        nav.stoppingDistance = offset;
        nav.SetDestination(player.transform.position);
        if (playeranim.GetCurrentAnimatorStateInfo(0).IsName("idle1"))
        {
            
            anim.SetBool("isWalking", false);   
        }
        else
        {
            anim.SetBool("isWalking", true);
        }
    }

 
    private bool doingTask()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            setAllTasksFalse();
            targetObj = null;
            hasTarget = false;
        }
        else if (hasTarget)
        {
            if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1)))
            {
                setAllTasksFalse();
                goPush = true;
            }

            if ((Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2)))
            {
                setAllTasksFalse();
                goCarry = true;
            }
        }

        return (goPush || goCarry);
    }

    public void setAllTasksFalse()
    {
        goWait = false;
        goPush = false;
        goPull = false;
        goStack = false;
        goCarry = false;
    }
}
