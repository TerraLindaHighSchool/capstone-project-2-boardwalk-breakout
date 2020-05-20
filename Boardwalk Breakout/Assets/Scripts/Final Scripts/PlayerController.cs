using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isGrounded;
    Rigidbody rb;

    float speed = 10;
    float rotSpeed = 80;
    //float rot = 0f;
    float gravity = 8;
    float jumpHeight = 3f;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FollowCommand.player = gameObject;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
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
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 1);
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }

            if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool("walkBackwards", true);
                moveDir = new Vector3(0, 0, -1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }

            //Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetInteger("condition", 0);
                anim.SetBool("walkBackwards", false);
                anim.SetBool("isJumping", true);
                Debug.Log(anim.GetBool("isJumping"));
                moveDir += new Vector3(0, jumpHeight, 0);
            }
            else
            {
                anim.SetBool("isJumping", false);
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("condition", 0);
            moveDir = new Vector3(0, 0, 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("walkBackwards", false);
            moveDir = new Vector3(0, 0, 0);
        }

        if (Input.GetKey("d"))
        {
            this.transform.Rotate(Vector3.up, rotSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            this.transform.Rotate(Vector3.up, -rotSpeed * Time.deltaTime);
        }
        
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
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
