using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pull : MonoBehaviour
{
    public int numPlushReq;
    public float speed = 10;
    public GameObject objectPulled;

    [Header("Direction")]
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
        if (numPlush >= numPlushReq)
        {
            if (backward)
                objectPulled.transform.position += transform.forward * Time.deltaTime * speed;
            //x axis (red)
            if (right)
                objectPulled.transform.position -= transform.right * Time.deltaTime * speed;
            if (left)
                objectPulled.transform.position += transform.right * Time.deltaTime * speed;
        }
    }
}
