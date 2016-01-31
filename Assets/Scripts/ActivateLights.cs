using UnityEngine;
using System.Collections;

public class ActivateLights : MonoBehaviour {
    public Material skybox;
    public Light directionalLight;
    public Light entranceSpotlight;
    public Light keySpotlight;

    void OnTriggerEnter()
    {
        RenderSettings.skybox = skybox;
        directionalLight.enabled = true;
        entranceSpotlight.enabled = false;
        keySpotlight.enabled = false;

        
    }
}
