using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
