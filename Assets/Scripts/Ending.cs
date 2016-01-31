using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ending : MonoBehaviour {

    GameObject player;
    Quaternion playerRotation;
    Vector3 playerPosition;

    public Camera cam;
    public Text text;

    bool isDone = false;
    public float speed;

    public FadeInOut fader;

    void Start()
    {
        fader = GameObject.FindObjectOfType<FadeInOut>();
    }

    void FixedUpdate()
    {
        if (isDone == true)
        {
            print("TEA");
            cam.transform.Translate(new Vector3(0, speed));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            player = other.gameObject;
            playerPosition = player.transform.position;
            playerRotation = player.transform.rotation;
            player.SetActive(false);
            cam.transform.position = playerPosition;
            cam.transform.rotation = playerRotation;
            text.enabled = true;
            isDone = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            

        }
    }
}
