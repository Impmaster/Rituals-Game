using UnityEngine;

public class MirroredBlock : MonoBehaviour {
    public int Location = 5;
    public Vector3[] Positions;
    public float MoveTime = 1f;

    void Start () {
        if (Positions.Length < 9)
            Debug.LogWarning("Fewer than 9 positions");
    }

    void Update () {
    }

    public void SetLocation(int location) {
        if (location != this.Location) {
            Debug.Log("Moving " + gameObject.name + " to " + location);
            this.Location = location;
            LeanTween.moveLocal(gameObject, Positions[location - 1], MoveTime);
        }
    }
}
