using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public int numPlushReq;
    public float speed = 8;
    public static GameObject player { get; set; }

    private bool stopped;
    private List<GameObject> plushies = new List<GameObject>();

    //private GameObject objectPushed;
    [Header("Direction")] 
    [SerializeField]
    public bool forward;
    [SerializeField]
    public bool backward;
    [SerializeField]
    public bool left;
    [SerializeField]
    public bool right;

    private void Start()
    {
        //objectPushed = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plushie")
        {
            if (other.GetComponent<FollowCommand>().goPush)
                plushies.Add(other.gameObject);
            else if (other.GetComponent<FollowCommand>().goCarry)
                Debug.Log("SET ACTIVE You cannot carry this object, you imbecile. Try something else.");
        }
        else if (other.tag == "Stop")
            stopped = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plushie")
        {
            plushies.Remove(other.gameObject);
            Debug.Log("SET INACTIVE You cannot carry this object, you imbecile. Try something else.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopped)
        {
            if (plushies.Count >= numPlushReq)
            {
                Debug.Log("SET INACTIVE You need more plushies to push this object, you imbecile.");
                //z axis (blue)
                if (forward)
                    transform.position += transform.forward * Time.deltaTime * speed;
                if (backward)
                    transform.position -= transform.forward * Time.deltaTime * speed;
                //x axis (red)
                if (right)
                    transform.position += transform.right * Time.deltaTime * speed;
                if (left)
                    transform.position -= transform.right * Time.deltaTime * speed;
            }
            else if (plushies.Count > 0)
                Debug.Log("SET ACTIVE You need more plushies to push this object, you imbecile.");
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
