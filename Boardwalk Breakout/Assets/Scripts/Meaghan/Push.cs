using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public int numPlushReq;
    public float speed = 8;
    public GameObject objectPushed;
    public GameObject stopPoint; //empty gameobject MUST HAVE COLLIDER THAT INTERECTS W DESIRED DIRECTION

    private bool stopped;
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
        else if (other.gameObject == stopPoint)
            stopped = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Plushie"))
            plushies.Remove(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(plushies.Count >= numPlushReq && !stopped)
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
