using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    [Header("References")]
    AudioSource audioSource;
    public GameController gameController;

    [Header("Audio")]
    [SerializeField] AudioClip collectableSound;
    [SerializeField] float collectableSoundVolume = 10f;

    [Header("Other")]
    [SerializeField] float rotationSpeed = 10f;
    bool isTriggered = false;
    MeshRenderer[] collectableParts;
    
    void Start()
    {
        collectableParts = GetComponentsInChildren<MeshRenderer>();
    }

    void Update()
    {
        transform.Rotate(Vector3.down * (rotationSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isTriggered == true) { return; } // stops multiple triggers with different parts of rocketship.

        if (gameController.rocket.isAlive)
        {
            isTriggered = true;
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = PlayerPrefsController.GetOtherVolume();
            audioSource.PlayOneShot(collectableSound, collectableSoundVolume);
            gameController.IncreseCollectables();
            foreach (MeshRenderer part in collectableParts)
            {
                part.GetComponent<MeshRenderer>().enabled = false;
            }
            Destroy(gameObject, 2f);
        }
    }
}
