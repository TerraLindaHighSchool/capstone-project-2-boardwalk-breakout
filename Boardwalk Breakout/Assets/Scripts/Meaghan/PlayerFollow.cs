using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For the Camera to follow the player.

public class PlayerFollow : MonoBehaviour
{
    public Transform PlayerTrans;

    private Vector3 cameraOffset;

    private float SmoothFactor = 1.0f;

    public float RotationSpeed = 2.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - PlayerTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
  
        Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

        cameraOffset = camTurnAngle * cameraOffset;


        Vector3 newPos = PlayerTrans.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        transform.LookAt(PlayerTrans);
    }
}
