using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

        if (!GameObject.Find("Beam").GetComponent<GrabPlushie>().isDead && !GameObject.Find("Exit").GetComponent<Win>().isWin)
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
            if (Input.GetKey("d"))
            {
                this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
            if (Input.GetKey("a"))
            {
                this.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }
        }
        
    }
}





