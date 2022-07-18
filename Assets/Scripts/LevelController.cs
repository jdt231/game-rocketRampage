using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelController : MonoBehaviour
{
    public LevelButtonController[] levelButtons;

    public MusicPlayer musicPlayer;
    public Text totalMedalsText;

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;
    public int levelReached;

    public int medalsEarnedTotal;

    public bool isMenuScene;

    private void Start()
    {
        NewLevelSetUp();

        if (!musicPlayer)
        {
            musicPlayer = FindObjectOfType<MusicPlayer>();
        }

        SetMusic();

    }

    private void NewLevelSetUp()
    {
        if (levelButtons.Length <= 0) { return; }

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int thisLevelsMedals = PlayerPrefs.GetInt("stars" + levelButtons[i].name, 0);
            medalsEarnedTotal = medalsEarnedTotal + thisLevelsMedals;
        }

        totalMedalsText.text = "x " + medalsEarnedTotal;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (levelButtons[i].minimumMedalsRequired > medalsEarnedTotal)
            {
                levelButtons[i].GetComponent<Button>().interactable = false;
                levelButtons[i].SetButtonInactive();
            }
            else
            {
                levelButtons[i].UpdateText();
            }
        }
        
        GameObject scrollBar = GameObject.Find("Scrollbar");
        scrollBar.GetComponent<Scrollbar>().value = 1;
    }

    private void SetMusic()
    {
        if (isMenuScene == true)
        {
            musicPlayer.PlayMenuMusic();
        }
        else
        {
            musicPlayer.ChangeMusic();
        }
    }

    public void RestartScene()
    {
        musicPlayer.newScene = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void LoadNextScene()
    {
        int maxScenesInBuildIndex = SceneManager.sceneCountInBuildSettings - 1;
        int nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneToLoad <= maxScenesInBuildIndex)
        {
            musicPlayer.newScene = true;
            SceneManager.LoadScene(nextSceneToLoad);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.LogWarning("There is no other available scenes to load");
        }
    }

    public void LoadPreviousScene()
    {
        int maxScenesInBuildIndex = SceneManager.sceneCountInBuildSettings - 1;
        int nextSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;

        if (nextSceneToLoad <= maxScenesInBuildIndex)
        {
            print("Load Previous Scene called");
            musicPlayer.newScene = true;
            SceneManager.LoadScene(nextSceneToLoad);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.LogWarning("There is no other available scenes to load");
        }
    }

    public void LoadLevelSelect()
    {
        musicPlayer.newScene = true;
        SceneManager.LoadScene("Level Select");
        Time.timeScale = 1f;
    }

    public void LoadMenuScene()
    {
        musicPlayer.newScene = true;
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void LoadControlsScene()
    {
        musicPlayer.newScene = true;
        SceneManager.LoadScene("How To Play");
        Time.timeScale = 1f;
    }

    public void LoadSettingsScene()
    {
        musicPlayer.newScene = true;
        SceneManager.LoadScene("Settings");
        Time.timeScale = 1f;
    }

    public void LoadSelectedLevel(string levelName)
    {
        musicPlayer.newScene = true;
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1f;
    }

    public void LoadTutorialScene()
    {
        musicPlayer.newScene = true;
        SceneManager.LoadScene("Tutorial 1 - Gameplay");
        Time.timeScale = 1f;
    }

    public void LoadAboutScene()
    {
        musicPlayer.newScene = true;
        SceneManager.LoadScene("About");
        Time.timeScale = 1f;
    }

    public void LoadCreditsScene()
    {
        musicPlayer.newScene = true;
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpdateLevelsUnlocked()
    {
        levelReached = PlayerPrefs.GetInt("levelReached");
        if (levelReached >= levelToUnlock) { return; }

        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }

    public void ResetLevelsUnlockedProgress()
    {
        PlayerPrefs.SetInt("levelReached", 1);
        Debug.Log("Resetting Level Progress");
    }

    public void ResetAllBestTimes() // FIX AFTER LEVELBUTTONS CHANGE
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            FindObjectOfType<TimerController>().ResetBestTime(levelButtons[i].name);
        }
        Debug.Log("Resetting Best Times");
    }
}
