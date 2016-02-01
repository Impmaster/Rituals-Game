using UnityEngine;

public class BlockMove : MonoBehaviour
{
    private const float EaseDistance = 0.25f;

    public enum MoveAxis { X, Y, Z }

    public float Speed = 10;
    public MoveAxis Axis = MoveAxis.X;
    public float Distance = 20;

    private Vector3 _origin;

    Vector3 newPosition;

    private bool playerOnTop;
    GameObject player;
    Vector3 oldPosition;

    void Start()
    {
        _origin = transform.localPosition;
    }

    void Update()
    {
        Vector3 axis = Vector3.zero;
        switch (Axis)
        {
            case MoveAxis.X: axis = Vector3.right; break;
            case MoveAxis.Y: axis = Vector3.up; break;
            case MoveAxis.Z: axis = Vector3.forward; break;
        }

        // Bounce from 0 to 1 and back
        float pos = Time.time * Speed / Distance;
        pos %= 2;
        if (pos > 1) pos = 2 - pos;

        // Ease
        pos = easeInOutSine(pos, 0, 1, 1);

        // Translate
        oldPosition = newPosition;
        newPosition = _origin + axis * Distance * pos;
        transform.localPosition = newPosition;

        if (playerOnTop)
        {
            player.transform.position += (newPosition - oldPosition);
        }
    }

    private float easeInOutSine(float t, float b, float c, float d)
    {
        // based on http://gizma.com/easing/#sin3
        return -c / 2 * (Mathf.Cos(Mathf.PI * t / d) - 1) + b;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            player = other.gameObject;
            playerOnTop = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            playerOnTop = false;
        }
    }
}
