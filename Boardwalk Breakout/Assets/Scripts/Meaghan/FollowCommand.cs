using System.Collections;
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
    


    [SerializeField] private float offset = 2.0f;
    public GameObject player;
    private NavMeshAgent navMeshAgent;

    //****temporary object to replace selection****
    public GameObject targetObj;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!doingTask())
            Follow();
        else
        {
            GetComponent<NavMeshAgent>().stoppingDistance = 0;
            GetComponent<NavMeshAgent>().SetDestination(targetObj.transform.position);
        }

    }

    private void Follow()
    {
        setAllTasksFalse();
        GetComponent<NavMeshAgent>().stoppingDistance = offset;
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }

    private bool doingTask()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            setAllTasksFalse();
        }
        if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
        {
            setAllTasksFalse();
            goPush = true;
        }
        if (Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Keypad2))
        {
            setAllTasksFalse();
            goCarry = true;
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
