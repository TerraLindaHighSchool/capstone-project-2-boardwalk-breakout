using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20.0f;
    public float rotationSpeed = 70.0f;

    bool isGrounded;
    Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

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


    void Update()
    {

        if (Input.GetKey("w"))
        {
            //pos.z += speed * Time.deltaTime;
            rb.AddRelativeForce(Vector3.forward * speed);
        }
        if (Input.GetKey("s"))
        {
            //pos.z -= speed * Time.deltaTime;

            rb.AddRelativeForce(Vector3.forward * -speed);
        }
        if (Input.GetAxis("Mouse X") < 0)
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        if (Input.GetAxis("Mouse X") > 0)
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);



    }
}





