using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isGrounded;
    bool isMoving;
    Rigidbody rb;

    float speed = 10;
    float rotSpeed = 80;
    //float rot = 0f;
    float gravity = 8;
    float jumpHeight = 3f;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    private GameObject[] plushies;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        FollowCommand.player = gameObject;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        isGrounded = true;
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

        /*if (collision.gameObject.tag.Equals("Plushie"))
        {
            plushies = GameObject.FindGameObjectsWithTag("Plushie");
            foreach (GameObject p in plushies)
            {
                p.transform.position = new Vector3(0, 0, 0);
            }
        }*/
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
                isMoving = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool("walkBackwards", true);
                moveDir = new Vector3(0, 0, -1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
                isMoving = true;
            }

            //Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetInteger("condition", 0);
                anim.SetBool("walkBackwards", false);
                anim.SetBool("isJumping", true);
                Debug.Log(anim.GetBool("isJumping"));
                if(isMoving)
                    moveDir += new Vector3(0, jumpHeight, 0);
                else
                    moveDir = new Vector3(0, jumpHeight, 0);
            }
            else
            {
                anim.SetBool("isJumping", false);
            }

            isMoving = false;
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
