﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public AudioClip shoutingClip;
    public float turnSmoothing = 15f;
    public float speedDampTime = 0.1f;

    private Animator anim;
    private HashIDs hash;
    private Rigidbody rigidbody;
    private AudioSource audio;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool sneak = Input.GetButton("Sneak");

        MovementManagement(h, v, sneak);
    }

    void MovementManagement(float horizontal, float vertical, bool sneaking)
    {
        anim.SetBool(hash.sneakingBool, sneaking);
        if(horizontal != 0f || vertical != 0f)
        {
            Rotating(horizontal, vertical);
            anim.SetFloat(hash.speedFloat, 5.5f, speedDampTime, Time.deltaTime);
        }
        else
        {
            anim.SetFloat(hash.speedFloat, 0f);
        }
    }

    void Rotating(float horizontal, float vertical)
    {
        Vector3 targetDirection = new Vector3(horizontal, 0, vertical);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        Quaternion newRotation = Quaternion.Lerp(rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
        rigidbody.MoveRotation(newRotation);
    }

    void AudioManegement(bool shout)
    {
        if(anim.GetCurrentAnimatorStateInfo(0).nameHash == hash.locomotionState)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        else
        {
            audio.Stop();
        }
        if (shout)
        {
            AudioSource.PlayClipAtPoint(shoutingClip, transform.position);
        }
    }

    // Use this for initialization
    void Start () {
        anim.SetLayerWeight(1, 1f);
    }

    // Update is called once per frame
    void Update () {
        bool shout = Input.GetButtonDown("Attract");
        anim.SetBool(hash.shoutingBool, shout);
        AudioManegement(shout);
	}
}
