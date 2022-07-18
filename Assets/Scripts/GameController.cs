using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Collectables")]
    public Text collectableText;
    public int currentCollectables = 0;
    public int maxCollectables = 0;

    [Header("UI")]
    public Canvas levelCompleteCanvas;
    public Canvas pauseMenuCanvas;
    public Canvas gameOverCanvas;
    public Canvas inputCanvas;
    public Canvas mainCanvas;
    public Text startingText;
    public Text targetTimeText;
    public ButtonPressed thrustButton;

    [Header("Controllers")]
    public Rocket rocket;
    public TimerController timerController;
    public LevelController levelController;
    public DeathWallController deathWallController;
    public DebugController debugController;
    public ScoreController scoreController;
    public UIController uiController;

    [Header("Other")]
    public bool paused = false;
    bool rocketStarted = false;
    public int medalScore;
    public AudioSource[] allSounds;

    [Header("Time to beat level")]
    public int minutes;
    public int seconds;
    public TimeSpan timeTarget;


    void Start()
    {
        //timeTarget = new TimeSpan(0, minutes, seconds);
        allSounds = FindObjectsOfType<AudioSource>();
        timeTarget = new TimeSpan(0, 0, minutes, seconds, 0);
        pauseMenuCanvas.enabled = false;
        levelCompleteCanvas.enabled = false;
        gameOverCanvas.enabled = false;
        rocket.isAlive = false;
        targetTimeText.text = "target time: " + timeTarget.ToString("mm':'ss'.'ff"); ;
        ManageCollectables();
    }

    void Update()
    {
        ManageTimer();
        ManageLevelRestart();

        if (!rocketStarted)
        { OnRocketActivated(); }
    }

    public void PauseGame()
    {
        paused = TogglePause();
    }

    private bool TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            
            Time.timeScale = 1f;
            pauseMenuCanvas.enabled = false;
            mainCanvas.enabled = true;
            startingText.enabled = true;
            inputCanvas.enabled = true;
            UnMuteAllSounds();
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            pauseMenuCanvas.enabled = true;
            mainCanvas.enabled = false;
            startingText.enabled = false;
            inputCanvas.enabled = false;
            MuteAllSounds();
            return (true);
        }
    }

    private void ManageTimer()
    {
        if (!rocket.isAlive)
        {
            timerController.EndTimer();
        }
    }

    private void ManageLevelRestart()
    {
        if (Input.GetKeyDown(KeyCode.W) && gameOverCanvas.enabled == true)
        {
            levelController.RestartScene();
        }
    }

    public void OnRocketActivated()
    {
        if ((Input.GetKey(KeyCode.Space) || thrustButton.buttonPressed == true) && paused == false)
        {
            rocketStarted = true;
            rocket.isAlive = true;
            startingText.gameObject.SetActive(false);
            timerController.BeginTimer();
            deathWallController.StartCoroutine("StartWallMoving");
        }
    }

    private void ManageCollectables()
    {
        maxCollectables = FindObjectsOfType<Collectable>().Length;
        collectableText.text = ("collectables: " + currentCollectables.ToString() + "/" + maxCollectables);
    }

    public void IncreseCollectables()
    {
        currentCollectables++;
        collectableText.text = ("collectables: " + currentCollectables.ToString() + "/" + maxCollectables);
    }

    public void TriggerWinScreen()
    {
        inputCanvas.enabled = false;
        mainCanvas.enabled = false;
        levelCompleteCanvas.enabled = true;
    }

    public void TriggerLoseScreen()
    {
        inputCanvas.enabled = false;
        mainCanvas.enabled = false;
        gameOverCanvas.enabled = true;
    }

    public void CalculateStarsScored()
    {
        string currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        medalScore = 1;

        if (currentCollectables >= maxCollectables)
        {
            medalScore++;
        }

        if (timerController.timePlaying <= timeTarget)
        {
            medalScore++;
        }

        if (medalScore > PlayerPrefs.GetInt("stars" + currentLevel))
        {
            scoreController.UpdateStarScore(medalScore);
        }
    }

    public void MuteAllSounds()
    {
        rocket.thrusterAudio.Pause();
        foreach (AudioSource audio in allSounds)
        {
            if (audio)
            {audio.mute = true;}
        }
        FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>().mute = false;
    }

    public void UnMuteAllSounds()
    {
        foreach (AudioSource audio in allSounds)
        {
            if (audio)
            {audio.mute = false;}
        }
        rocket.thrusterAudio.Play();
        rocket.thrusterAudio.mute = true;
    }

    public void UpdateAllSounds(float newVolume)
    {
        foreach (AudioSource audio in allSounds)
        {
            if (audio) 
            { audio.volume = newVolume; }
        }
    }
}
