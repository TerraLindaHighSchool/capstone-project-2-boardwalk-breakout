using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 4;
    float rotSpeed = 80;
    //float rot = 0f;
    float gravity = 8;
    float jumpHeight = 3.5f;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anim.SetInteger("condition", 1);
                Debug.Log(anim.GetInteger("condition"));
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool("walkBackwards", true);
                moveDir = new Vector3(0, 0, -1);
                moveDir *= speed;
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

            //Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("isJumping", true);
                Debug.Log(anim.GetBool("isJumping"));
                moveDir = new Vector3(0, jumpHeight, 0);
            }else
            {
                anim.SetBool("isJumping", false);
            }

           /* if (Input.GetKeyUp(KeyCode.Space))
            {
                anim.SetBool("isJumping", false);
                Debug.Log(anim.GetBool("isJumping"));
                //moveDir = new Vector3(0, 0, 0);
            }*/
        }
        //rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        //transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
    /*
     * public bool isGrounded = false;
    void Update()
    {
        jump();
    }
    void jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
        }
    }
     *
     * 
     */
}
