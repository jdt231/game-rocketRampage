using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Text musicVolumeSliderText;
    [SerializeField] float musicDefaultVolume = 0.5f;

    [SerializeField] Slider sfxVolumeSlider;
    [SerializeField] Text sfxVolumeSliderText;
    [SerializeField] float sfxDefaultVolume = 0.5f;

    [SerializeField] Canvas resetPanel;

    //[SerializeField] Slider sensitivitySlider;
    //[SerializeField] Text sensitivitySliderText;
    //[SerializeField] float defaultSensitivity = 5f;

    int isDefaultSet;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        LoadCurrentSettings();
        if(resetPanel)
        { resetPanel.enabled = false; }
    }

    public void LoadCurrentSettings()
    {
        if (musicVolumeSlider && sfxVolumeSlider)
        {
            musicVolumeSlider.value = PlayerPrefsController.GetMasterVolume();
            sfxVolumeSlider.value = PlayerPrefsController.GetOtherVolume();
        }

        //if (sensitivitySlider)
        //{
        //    sensitivitySlider.value = PlayerPrefsController.GetShipSensitivity();
        //}

        ManageDefaults();
    }

    private void ManageDefaults()
    {
        isDefaultSet = PlayerPrefs.GetInt("defaultSet", 0);
        if (isDefaultSet != 0) { return; }

        if (musicVolumeSlider && sfxVolumeSlider)
        {
            PlayerPrefsController.SetMasterVolume(musicDefaultVolume);
            PlayerPrefsController.SetOtherVolume(sfxDefaultVolume);
        }
        //if (sensitivitySlider)
        //{
        //    PlayerPrefsController.SetShipSensitivity(defaultSensitivity);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (musicVolumeSlider && sfxVolumeSlider)
        {
            ManageMusicPlayer();
            ManageSliderText();
        }
    }

    private void ManageSliderText()
    {
        musicVolumeSliderText.text = (musicVolumeSlider.value * 100).ToString("F0"); // "F0" converts the string to show no decimal spaces
        sfxVolumeSliderText.text = (sfxVolumeSlider.value * 100).ToString("F0");

        //if (sensitivitySlider)
        //{
        //    sensitivitySliderText.text = sensitivitySlider.value.ToString("F0");
        //}
    }

    private void ManageMusicPlayer()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(musicVolumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(musicVolumeSlider.value);
        PlayerPrefsController.SetOtherVolume(sfxVolumeSlider.value);
        //PlayerPrefsController.SetShipSensitivity(sensitivitySlider.value);
        PlayerPrefs.SetInt("defaultSet", 1);
        FindObjectOfType<LevelController>().LoadMenuScene();
    }

    public void SaveSettings()
    {
        PlayerPrefsController.SetMasterVolume(musicVolumeSlider.value);
        PlayerPrefsController.SetOtherVolume(sfxVolumeSlider.value);
        PlayerPrefs.SetInt("defaultSet", 1);
    }

    public void SetDefaults()
    {
        musicVolumeSlider.value = musicDefaultVolume;
        sfxVolumeSlider.value = sfxDefaultVolume;
        //if (sensitivitySlider)
        //{
        //    sensitivitySlider.value = defaultSensitivity;
        //}
    }

    public void ManageAllSounds()
    {
        float newVolume = sfxVolumeSlider.value;
        gameController.UpdateAllSounds(newVolume);
    }

    public void ResetProgressCanvas()
    {
        if (resetPanel.enabled == false)
        { resetPanel.enabled = true;}
        else
        { resetPanel.enabled = false; }
    }
}
