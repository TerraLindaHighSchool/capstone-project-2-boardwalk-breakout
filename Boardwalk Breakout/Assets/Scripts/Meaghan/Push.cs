using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public int numPlushReq;
    public float speed = 3;
    public GameObject objectPushed;

    private List<GameObject> plushies = new List<GameObject>();

    [Header("Direction")]
    [SerializeField]
    bool forward;
    [SerializeField]
    bool backward;
    [SerializeField]
    bool left;
    [SerializeField]
    bool right;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plushie" && other.GetComponent<FollowCommand>().goPush)
        {
            plushies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
            plushies.Remove(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(plushies.Count >= numPlushReq)
        {
            //z axis (blue)
            if(forward)
                objectPushed.transform.position += transform.forward * Time.deltaTime * speed;
            if (backward)
                objectPushed.transform.position -= transform.forward * Time.deltaTime * speed;
            //x axis (red)
            if (right)
                objectPushed.transform.position += transform.right * Time.deltaTime * speed;
            if (left)
                objectPushed.transform.position -= transform.right * Time.deltaTime * speed;
        }
    }
}
