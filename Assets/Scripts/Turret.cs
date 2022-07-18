using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform rocket;
    public Transform fireStart;
    public GameObject bullet;

    float distanceFromRocket;
    public float firingDistance = 30f;
    public float firingSpeed = 3f;
    public float bulletSpeed = 10f;

    public float velX = 0;
    public float velY = 0;
    public float velZ = 0;

    bool isActive = true;

    private void Start()
    {
        if (!rocket)
        {
            rocket = FindObjectOfType<Rocket>().transform;
        }
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        LookAtRocket();
        CalculateDistanceFromRocket();

    }

    private IEnumerator Fire()
    {
        while (isActive)
        {
            if (distanceFromRocket < firingDistance)
            {
                Debug.Log("Firing gun");
                GameObject clone = Instantiate(bullet, fireStart.transform.position, transform.rotation);
                clone.GetComponent<Rigidbody>().velocity = new Vector3(rocket.transform.position.x, rocket.transform.position.y, rocket.transform.position.z);
            }
            yield return new WaitForSeconds(firingSpeed);
        }
    }

    private void LookAtRocket()
    {
        transform.LookAt(rocket);
    }

    private void CalculateDistanceFromRocket()
    {
        if (rocket)
        {
            distanceFromRocket = Vector3.Distance(rocket.transform.position, transform.position);
            print(distanceFromRocket);
        }
    }
}
