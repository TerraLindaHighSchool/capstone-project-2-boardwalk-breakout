﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public int numPlushReq;
    public float speed = 8;
    public GameObject objectPushed;

    private bool stopped;
    private List<GameObject> plushies = new List<GameObject>();

    [Header("Direction")] 
    [SerializeField]
    public bool forward;
    [SerializeField]
    public bool backward;
    [SerializeField]
    public bool left;
    [SerializeField]
    public bool right;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plushie" && other.GetComponent<FollowCommand>().goPush)
        {
            plushies.Add(other.gameObject);
        }
        else if (other.tag == "Stop")
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

    public void setAllDirectionsFalse()
    {
        forward = false;
        backward = false;
        left = false;
        right = false;
    }
}