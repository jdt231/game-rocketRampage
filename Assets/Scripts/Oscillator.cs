using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] // Only allows one version of this script to be attached to the game object

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    Vector3 startingPos;

    [SerializeField] float period = 2f;
    float movementFactor; // 0 for not moved, 1 for moved
    float time = 0;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } // protect against period is zero 

        time = Time.timeSinceLevelLoad; // resets on scene load so that position of object resets when the level does.
        float cycles = time / period; // grows constantly from zero e.g. if 6 seconds have passed in game and our period is 2, then 3 cycles have been completed (6/2 = 3)

        const float tau = Mathf.PI * 2f; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

        movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;

        transform.position = startingPos + offset;
    }
}
