using UnityEngine;

/// <summary>
/// Applies a directional force to any rigidbody the player controller collides with.
/// </summary>
public class T_PushObject : MonoBehaviour
{
    // Force applied to objects when pushed
    public float pushForce = 1f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Get the Rigidbody component attached to the object that was hit
        Rigidbody rB = hit.collider.attachedRigidbody;

        // Checks if the object has a Rigidbody and is not kinematic
        if (rB != null && !rB.isKinematic)
        {
            // Create a force direction vector based on the players movement, ignoring the Y axis (no vertical)
            Vector3 forceDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            
            // Get the point of contact on the object
            Vector3 collisionPoint = hit.point;

            rB.AddForceAtPosition(forceDirection * pushForce, collisionPoint, ForceMode.Impulse);
        }
    }
}
