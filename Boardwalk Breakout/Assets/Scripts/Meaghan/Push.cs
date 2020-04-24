using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public int numPlushReq;
    public float speed = 3;
    public GameObject objectPushed;

    [Header("Direction")]
    [SerializeField]
    bool forward;
    [SerializeField]
    bool backward;
    [SerializeField]
    bool left;
    [SerializeField]
    bool right;


    private int numPlush;

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plushie")
        {
            numPlush++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plushie")
        {
            numPlush--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(numPlush >= numPlushReq)
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
