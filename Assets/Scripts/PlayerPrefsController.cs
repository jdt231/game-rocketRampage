using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string OTHER_VOLUME_KEY = "other volume";
    //const string SHIP_SENSITIVITY_KEY = "ship sensitivity";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const float OTHER_MIN_VOLUME = 0f;
    const float OTHER_MAX_VOLUME = 1f;

    //const float MIN_SENSITIVITY = 1f;
    //const float MAX_SENSITIVITY = 10f;

    private void Start()
    {
        //PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, 0.5f);  RESTORE IF REQUIRED FOLLOWING TESTING
        //PlayerPrefs.SetFloat(OTHER_VOLUME_KEY, 0.5f);  RESTORE IF REQUIRED FOLLOWING TESTING

        float startingMusicVolume = GetMasterVolume();
        float startingOtherVolume = GetOtherVolume();
        SetMasterVolume(startingMusicVolume);
        SetOtherVolume(startingOtherVolume);

        //PlayerPrefs.SetFloat(SHIP_SENSITIVITY_KEY, 5f); REMOVE ONCE COMPLETED TESTING
    }

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume is out of range");
        }
    }

    public static void SetOtherVolume(float volume)
    {
        if (volume >= OTHER_MIN_VOLUME && volume <= OTHER_MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(OTHER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Other volume is out of range");
        }
    }

    //public static void SetShipSensitivity(float sensitivity)
    //{
    //    if (sensitivity >= MIN_SENSITIVITY && sensitivity <= MAX_SENSITIVITY)
    //    {
    //        PlayerPrefs.SetFloat(SHIP_SENSITIVITY_KEY, sensitivity);
    //    }
    //    else
    //    {
    //        Debug.LogError("Ship sensitivity is out of range");
    //    }
    //}

    //public static float GetShipSensitivity()
    //{
    //    //return PlayerPrefs.GetFloat(SHIP_SENSITIVITY_KEY);
    //}

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, 0.5f);
    }

    public static float GetOtherVolume()
    {
        return PlayerPrefs.GetFloat(OTHER_VOLUME_KEY, 0.5f);
    }

}
