using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            myRigidbody.AddRelativeForce(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            myRigidbody.AddRelativeForce(Vector3.down);
        }
        if (Input.GetKey(KeyCode.A))
        {
            myRigidbody.AddRelativeForce(Vector3.left);
        }
        if (Input.GetKey(KeyCode.W))
        {
            myRigidbody.AddRelativeForce(Vector3.right);
        }
    }
}
