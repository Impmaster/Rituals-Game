using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterPush : MonoBehaviour {
    public float PushForce = 0.3f;

    void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.AddForce(pushDir * PushForce, ForceMode.VelocityChange);
    }
}
