using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CheckerboardBlock : MonoBehaviour {
    public MirroredBlock MirroredBlock;

    public float PushForce = 15f;
    public float AtDestinationDistance = 0.1f;
    private Rigidbody _rigidbody;
    private Transform _pushDestination = null;

    void Start () {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update () {
        if (_pushDestination) {
            Vector3 force = _pushDestination.position - transform.position;
            force.y = 0; // no up/down

            if (force.magnitude > AtDestinationDistance) {
                // Move toward the destination
                force.Normalize();
                force *= PushForce;
                _rigidbody.AddForce(force, ForceMode.Force);
            } else {
                // We've reached the destination
                _rigidbody.AddRelativeForce(-_rigidbody.velocity, ForceMode.VelocityChange);
                Debug.Log("Reached destination");
                _pushDestination = null;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Pad") {
            _pushDestination = other.transform;
            int number = other.GetComponent<CheckerboardPad>().Number;
            MirroredBlock.SetLocation(number);
        }
    }
}
