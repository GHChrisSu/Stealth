using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlinking : MonoBehaviour {
    public float onTime;
    public float offTime;
    private float timer;
    private Renderer renderer;
    private Light light;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        light = GetComponent<Light>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (renderer.enabled && timer >= onTime)
        {
            SwithBeam();
        }
        if (!renderer.enabled && timer >= offTime)
        {
            SwithBeam();
        }
    }

    private void SwithBeam()
    {
        timer = 0f;
        renderer.enabled = !renderer.enabled;
        light.enabled = !light.enabled;
    }
}
