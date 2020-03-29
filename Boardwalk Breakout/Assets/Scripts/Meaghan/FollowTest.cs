using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowTest : MonoBehaviour
{

    [SerializeField] private float offset = 2.0f;
    public List<GameObject> plushies = new List<GameObject>();
    private GameObject player;
    private NavMeshAgent navMeshAgent;
    private void Start()
    {
        player = this.gameObject;
        navMeshAgent = gameObject.GetComponentInChildren<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag.Equals("Plushie"))
            //splushies.Add(collision.gameObject);
    }

    void Update()
    {
        for(int z = 0; z < plushies.Count; z++)
        {
            plushies[z].GetComponent<NavMeshAgent>().stoppingDistance = offset;
            plushies[z].GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }
        transform.LookAt(player.transform);
    }
}
