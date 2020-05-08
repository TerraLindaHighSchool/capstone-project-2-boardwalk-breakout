using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowCommand1 : MonoBehaviour
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
        GetComponent<NavMeshAgent>().stoppingDistance = offset;
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (!doingTask(0) || Input.GetKeyDown(KeyCode.Tab)) //FOLLOW
            Follow();
        else if (Input.GetKeyDown("1"))
                doingTask(1);
    }

    private void Follow()
    {
        setAllTasksFalse();
        GetComponent<NavMeshAgent>().stoppingDistance = offset;
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }

    private bool doingTask(int key) //0 if doing nothing
    {
        switch(key)
        {
            case 1:
                setAllTasksFalse();
                GetComponent<NavMeshAgent>().stoppingDistance = 0;
                GetComponent<NavMeshAgent>().SetDestination(targetObj.transform.position);
                return goPush = true;
        }
        
        return false;
    }

    private void setAllTasksFalse()
    {
        goWait = false;
        goPush = false;
        goPull = false;
        goStack = false;
        goCarry = false;
    }
}
