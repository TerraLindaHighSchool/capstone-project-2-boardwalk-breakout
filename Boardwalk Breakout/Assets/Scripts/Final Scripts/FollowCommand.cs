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


    public static GameObject targetObj { get; set; }
    public static GameObject player { get; set; }
    public static bool hasTarget { get; set; }


    [SerializeField] private float offset = 2.0f;
    private NavMeshAgent nav;

    Animator anim;




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
    }


    private bool doingTask()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            nav.isStopped = false;
            setAllTasksFalse();
            targetObj = null;
            hasTarget = false;
            anim.SetBool("isWalking", false);
        }
        else if ((Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Keypad3)))
        {
                anim.SetBool("isWalking", true);
                return nav.isStopped = false;
        }
        else if (hasTarget)
        {
            anim.SetBool("isWalking", true);
            if ((Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1)))
            {
                nav.isStopped = false;
                setAllTasksFalse();
                goPush = true;
            }

            if ((Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2)))
            {
                nav.isStopped = false;
                setAllTasksFalse();
                goCarry = true;
            }
        }

        return (goPush || goCarry);
    }

    public void setAllTasksFalse()
    {
        goPush = false;
        goPull = false;
        goStack = false;
        goCarry = false;
    }
}