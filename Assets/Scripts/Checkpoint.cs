using UnityEngine;

public class Checkpoint : MonoBehaviour {
    private Vector3 _lastCheckpointPosition;
    private Quaternion _lastCheckpointRotation;

	void Start() {
        _lastCheckpointPosition = Vector3.zero;
	}

    public void Restore() {
        if (_lastCheckpointPosition != Vector3.zero) {
            transform.position = _lastCheckpointPosition;
            transform.rotation = _lastCheckpointRotation;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Checkpoint") {
            Debug.Log("Checkpoint!");
            _lastCheckpointPosition = transform.position;
            _lastCheckpointRotation = transform.rotation;
        }
    }
}
