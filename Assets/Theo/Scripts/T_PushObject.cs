using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class T_PushObject : MonoBehaviour
{
    // Force applied to objects when pushed
    public float pushForce = 1f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Get the Rigidbody component of the object that was hit
        Rigidbody rB = hit.collider.attachedRigidbody;

        // Check if the object has a Rigidbody or it's not kinematic
        if (rB != null || !rB.isKinematic)
        {
            Vector3 forceDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            Vector3 collisionPoint = hit.point;
            rB.AddForceAtPosition(forceDirection * pushForce, collisionPoint, ForceMode.Impulse);
        }
    }
}
