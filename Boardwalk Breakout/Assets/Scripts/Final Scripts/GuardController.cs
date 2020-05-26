using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public static GameObject player { get; set; }
    public Transform[] waypoints;

    int m_CurrentWaypointIndex;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    void Update()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plushie" && other.GetComponent<FollowCommand>().enabled)
        {
            Destroy(other.gameObject);
            player.GetComponent<PlayerController>().count--;
        }
        else if (other.tag == "Player" && !other.isTrigger)
            WinLose.playerLost = true;
    }
}
