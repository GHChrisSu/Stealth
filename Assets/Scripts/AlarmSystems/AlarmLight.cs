﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    public float fadeSpeed = 2f;
    public float highIntensity = 2f;
    public float lowIntensity = 0.5f;
    public float changeMargin = 0.2f;
    [HideInInspector]
    public bool alarmOn;

    private float targetIntensity;
    private Light light;

    private void Awake()
    {
        light = GetComponent<Light>();
        light.intensity = 0f;
        targetIntensity = highIntensity;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (alarmOn)
        {
            light.intensity = Mathf.Lerp(light.intensity, targetIntensity, fadeSpeed * Time.deltaTime);
            CheckTargetIntensity();
        }
        else
        {
            light.intensity = Mathf.Lerp(light.intensity, 0, fadeSpeed * Time.deltaTime);
        }
    }

    private void CheckTargetIntensity()
    {
        if (Mathf.Abs(targetIntensity - light.intensity) < changeMargin)
        {
            if (targetIntensity == highIntensity)
            {
                targetIntensity = lowIntensity;

            }
            else
            {
                targetIntensity = highIntensity;
            }
        }
    }
}
