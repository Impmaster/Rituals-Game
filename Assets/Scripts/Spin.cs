using UnityEngine;

public class Spin : MonoBehaviour
{
    public float Speed = 3;
    /*
    private bool playerOnTop;
    GameObject player;
    Quaternion oldRotation;
    */
    void Update()
    {

        //oldRotation = transform.localRotation;
        transform.rotation *= Quaternion.AngleAxis(360 / Speed * Time.deltaTime, Vector3.up);


        

        /*
        if (playerOnTop)
        {
            //print(Quaternion.Angle(transform.localRotation, oldRotation));
            //player.transform.Translate(0, 5, 0);
            player.transform.rotation = new Quaternion(0, 90, 0, 0);
        }
        */

    }
    /*
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
    */
}