using UnityEngine;
using System.Collections;

public class ObjectPhysics : MonoBehaviour
{

    public float pushForce = 2.0f;

    /*Definition of On ControllerColliderHit
     * OnControllerColliderHit is called when the controller hits a collider while performing a Move.
     *This can be used to push objects when they collide with the character.
    */

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -.3f)
            return;

        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushForce * pushDirection;
    }
}
