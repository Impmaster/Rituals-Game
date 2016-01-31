using UnityEngine;
using System.Collections;

public class IntroLighting : MonoBehaviour {

    public Material startSkybox;
    public Light directionalLight;

	// Use this for initialization
	void Start () {
        RenderSettings.skybox = startSkybox;
        directionalLight.enabled = false;
	}
}
