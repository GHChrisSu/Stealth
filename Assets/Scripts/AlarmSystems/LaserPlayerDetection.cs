﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPlayerDetection : MonoBehaviour {
    private GameObject player;
    private LastPlayerSighting lastPlayerSighting;
    private Renderer renderer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
        lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
        renderer = GetComponent<Renderer>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (renderer.enabled)
        {
            if(other.gameObject == player)
            {
                lastPlayerSighting.position = other.transform.position;
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
