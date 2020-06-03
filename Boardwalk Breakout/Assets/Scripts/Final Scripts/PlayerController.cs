using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isGrounded;
    bool isMoving;
    


    //speed originally 10 
    float speed = 6;
    float rotSpeed = 80;
    //float rot = 0f;
    float gravity = 8;
    float jumpHeight = 3f;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    public int count { get; set; }
   

    void Start()
    {
        FollowCommand.player = gameObject;
        Push.player = gameObject;
        Carry.player = gameObject;
        GuardController.player = gameObject;
        WinLose.player = gameObject;
        StrengthTest.player = gameObject;
        WaterGun.player = gameObject;
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        isGrounded = true;
        count = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
            isGrounded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Plushie")
        {
            if (!other.gameObject.GetComponent<FollowCommand>().enabled)
            {
                count++;
                other.gameObject.GetComponent<FollowCommand>().enabled = true;
                other.gameObject.GetComponent<FollowCommand>().playerWait = true;
                WinLose.currentEvent = (float) WinLose.currentEvent + other.GetComponent<FollowCommand>().needsRescue;
                //Debug.Log(WinLose.currentEvent);
                //Debug.Log("This is " + count);
            }
            else if (!other.GetComponent<FollowCommand>().doingTask() == true)
                other.gameObject.GetComponent<FollowCommand>().playerWait = true;
        }

        else if (interactable(other.gameObject))
        {
            FollowCommand.targetObj = other.gameObject;
            FollowCommand.hasTarget = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Plushie")
            other.gameObject.GetComponent<FollowCommand>().playerWait = false;
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

