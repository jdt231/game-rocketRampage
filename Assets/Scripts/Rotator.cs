using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] // Only allows one version of this script to be attached to the game object

public class Rotator : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] bool rotateLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateLeft)
        {
            transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
        }
        else
        {
            transform.Rotate(Vector3.back * (rotationSpeed * Time.deltaTime));
        }

    }
}
