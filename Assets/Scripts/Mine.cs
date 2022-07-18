using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public AudioSource audioSource;
    public Rocket rocket;    
    public ParticleSystem explosionParticles;
    public AudioClip warningSound;
    public AudioClip finalSound;
    public AudioClip explosionSound;

    public Light mineLightLight;

    public bool lightActive = false;

    float mineBeepDelay;
    float distanceFromRocket;
    public float warningDistance = 10f;
    public float explodeDistance = 5f;

    public bool isActive = true;
    bool isWarning = false;
    bool isExploding = false;

    private void Start()
    {
        if (!rocket)
        {
            rocket = FindObjectOfType<Rocket>();
        }
        mineLightLight.enabled = false;
    }

    void Update()
    {
        CalculateDistanceFromRocket();
        SoundWarning();

        if (distanceFromRocket < explodeDistance && isActive && rocket.isAlive)
        {
            isActive = false;
            StartCoroutine(DetonateMine());
        }
    }

    private void CalculateDistanceFromRocket()
    {
        if (rocket)
        {
            distanceFromRocket = Vector3.Distance(rocket.transform.position, transform.position);
            mineBeepDelay = (distanceFromRocket / 20);
        }
    }

    private void SoundWarning()
    {
        if (distanceFromRocket < warningDistance && rocket.isAlive)
        {
            if (isWarning) { return; }
            else
            {
                isWarning = true;
                StartCoroutine(MineWarning());
            }
        }
        else 
        {
            isWarning = false;
        }
    }

    public IEnumerator MineWarning()
    {
        while (isActive && isWarning)
        {
            audioSource.volume = PlayerPrefsController.GetOtherVolume();
            audioSource.PlayOneShot(warningSound);
            StartCoroutine(MineLightFlash());
            yield return new WaitForSeconds(mineBeepDelay);
        }
    }

    public IEnumerator MineLightFlash()
    {
        ToggleLight();
        yield return new WaitForSeconds(0.2f);
        if (isActive)
        {
            ToggleLight();
        }   
    }

    public void ToggleLight()
    {
        lightActive = !lightActive;
        if (lightActive)    
        {
            mineLightLight.enabled = true;
        }
        else              
        {
            mineLightLight.enabled = false;
        }
    }

    public IEnumerator DetonateMine()
    {
        audioSource.Stop();
        
        audioSource.volume = PlayerPrefsController.GetOtherVolume();
        audioSource.PlayOneShot(finalSound);
        mineLightLight.enabled = true;
        yield return new WaitForSeconds(1);
        if (!isExploding)
        {
            ExplodeMine();
        }
    }

    public void ExplodeMine()
    {
        isExploding = true;
        audioSource.Stop();
        audioSource.volume = PlayerPrefsController.GetOtherVolume();
        audioSource.PlayOneShot(explosionSound);
        explosionParticles.Play();
        StartCoroutine(HandleExplosionCollider());
        transform.GetChild(1).gameObject.SetActive(false);
        Destroy(gameObject, 1f);
    }

    private IEnumerator HandleExplosionCollider()
    {
        gameObject.GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    public void TurnOffMine()
    {
        if (!isActive) { return; }

        isActive = false;
        mineLightLight.enabled = false;
        audioSource.Stop();

    }
}
