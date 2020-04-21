using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    /*
     *The object has to be a heavy mass if it has to take multiple plushies to move it
     * Or Increase the ground friction
     */
    Rigidbody rigidbody;
    float pushPower = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rigidbody.AddForce(Vector3.left * pushPower);
        }
    }
}
