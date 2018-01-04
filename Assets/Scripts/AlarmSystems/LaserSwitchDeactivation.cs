using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitchDeactivation : MonoBehaviour {
    public GameObject laser;
    public Material unlockMat;

    private GameObject player;
    private AudioSource audio;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            if (Input.GetButton("Switch"))
            {
                LaserDeactivation();
            }
        }
    }

    private void LaserDeactivation()
    {
        laser.SetActive(false);
        Renderer screen = transform.Find("prop_switchUnit").GetComponent<Renderer>();
        screen.material = unlockMat;
        audio.Play();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
