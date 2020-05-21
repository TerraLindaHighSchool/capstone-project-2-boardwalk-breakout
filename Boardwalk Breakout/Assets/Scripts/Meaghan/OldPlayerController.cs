using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float rotationSpeed = 70.0f;

    bool isGrounded;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FollowCommand.player = gameObject;
        GrabPlushie.player = gameObject;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
            isGrounded = true;
        else if (interactable(collision.gameObject))
        {
            FollowCommand.targetObj = collision.gameObject;
            FollowCommand.hasTarget = true;
        }
    }

    private void OnTriggerExit(Collider collision)
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
        if (Input.GetKey("d"))
        {
            this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            this.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        
    }

    bool interactable(GameObject obj)
        {
            if (obj.GetComponent<Push>() != null)
                return true;
            if (obj.GetComponent<Carry>() != null)
                return true;
            return false;
        }
}





