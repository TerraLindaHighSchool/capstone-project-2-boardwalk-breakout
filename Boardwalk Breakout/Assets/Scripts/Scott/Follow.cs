using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{

    [SerializeField] private float offset = 2.0f;
    private List<GameObject> kiddos = new List<GameObject>();
    private GameObject player;
    private NavMeshAgent navMeshAgent;
    private void Start()
    {
        player = this.gameObject;
        navMeshAgent = gameObject.GetComponentInChildren<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach(GameObject kid in kiddos)
        {
            if (collision.gameObject == kid)
                return;
        }
        if (collision.gameObject.tag.Equals("Plushie"))
            kiddos.Add(collision.gameObject);
    }

    void Update()
    {
        for(int z = 0; z < kiddos.Count; z++)
        {
            kiddos[z].GetComponent<NavMeshAgent>().stoppingDistance = offset;
            kiddos[z].GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
            if (navMeshAgent.hasPath)
                navMeshAgent.acceleration = (navMeshAgent.remainingDistance < closeEnoughMeters) ? deceleration : acceleration;
        }
    }
}
