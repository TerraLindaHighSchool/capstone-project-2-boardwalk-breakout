using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For the Camera to follow the player.

public class PlayerFollow : MonoBehaviour
{
    public Transform PlayerTrans;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;


    public bool LookAtPlayer = false;

    public bool RotatePlayer = true;


    public float RotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - PlayerTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (RotatePlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);

            cameraOffset = camTurnAngle * cameraOffset;
        }

        Vector3 newPos = PlayerTrans.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        if (LookAtPlayer || RotatePlayer)
            transform.LookAt(PlayerTrans);
    }
}
