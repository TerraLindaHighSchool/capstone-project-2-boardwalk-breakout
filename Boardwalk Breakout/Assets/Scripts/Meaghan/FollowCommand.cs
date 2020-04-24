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
            GetComponent<NavMeshAgent>().stoppingDistance = 1;
            GetComponent<NavMeshAgent>().SetDestination(targetObj.transform.position);
        }

    }

    private void Follow()
    {
        GetComponent<NavMeshAgent>().stoppingDistance = offset;
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }

    private bool doingTask()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            return setAllTasksFalse();
        }
        if (Input.GetKey("1"))
        {
            setAllTasksFalse();
            return goPush = true;
        }
        return false;
    }

    private bool setAllTasksFalse()
    {
        goWait = false;
        goPush = false;
        goPull = false;
        goStack = false;
        goCarry = false;
        return false;
    }
}
