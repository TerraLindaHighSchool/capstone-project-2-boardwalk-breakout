using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 20.0f;
    public float rotationSpeed = 70.0f;

    bool isGrounded;
    Rigidbody rb;

    //Animation
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Animation
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
            isGrounded = false;
    }

    void FixedUpdate()
    {
        //Animation
        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void Update()
    {

        if (Input.GetKey("w"))
        { 
            rb.AddRelativeForce(Vector3.forward * speed);
        }
        if (Input.GetKey("s"))
        {
            rb.AddRelativeForce(Vector3.forward * -speed);
        }

        /*
        if (Input.GetKey("d"))
        {
            this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            this.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }*/

       

    }
}
