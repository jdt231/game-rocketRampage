using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject straightLine;
    public GameObject fuzzyLine;
    public AudioSource laserSound;
    public float onTime = 2f;
    public float offTime = 3f;

    public bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToggleLaser());
    }

    IEnumerator ToggleLaser()
    {
        while (isActive == true)
        {
            laserSound.volume = PlayerPrefsController.GetOtherVolume();
            laserSound.Play();
            straightLine.SetActive(true);
            fuzzyLine.SetActive(true);
            yield return new WaitForSeconds(onTime);
            laserSound.Stop();
            straightLine.SetActive(false);
            fuzzyLine.SetActive(false);
            yield return new WaitForSeconds(offTime);
        }
    }

    public void TurnOffLaser()
    {
        isActive = false;
        laserSound.Stop();
        straightLine.SetActive(false);
        fuzzyLine.SetActive(false);
    }
}
