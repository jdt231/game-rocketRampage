using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timeCounter;

    public TimeSpan timePlaying;
    public TimeSpan bestTime;

    private bool timerGoing;
    public bool beatBestTime = false;
    private float elapsedTime;

    string currentLevel;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timeCounter.text = "Time: 00:00.00";
        timerGoing = false;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }

    public void ManageBestTime()
    {
        currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        GetCurrentBestTime(currentLevel);

        if (timePlaying >= bestTime)
        {
            Debug.Log("The new time was not better than best time");
        }
        else
        {
            beatBestTime = true;
            StoreBestTime(currentLevel); //Being called even if above if statement is true
        }

    }

    private void GetCurrentBestTime(string currentLevel)
    {
        int bestMinutes = PlayerPrefs.GetInt("bestMinutes" + currentLevel, 59); // Set initial time to beat: 99m:99s:99mm.
        int bestSeconds = PlayerPrefs.GetInt("bestSeconds" + currentLevel, 59);
        int bestMilliseconds = PlayerPrefs.GetInt("bestMilliseconds" + currentLevel, 99);

        bestTime = new TimeSpan(0, 0, bestMinutes, bestSeconds, bestMilliseconds);
    }

    private void StoreBestTime(string currentLevel)
    {
        PlayerPrefs.SetInt("bestMinutes" + currentLevel, timePlaying.Minutes);
        PlayerPrefs.SetInt("bestSeconds" + currentLevel, timePlaying.Seconds);
        PlayerPrefs.SetInt("bestMilliseconds" + currentLevel, timePlaying.Milliseconds);

        Debug.Log("New best time saved to PlayerPrefs is: "   //TODO - Remove when finished testing.
            + PlayerPrefs.GetInt("bestMinutes" + currentLevel) + ":"   //TODO - Remove when finished testing.
            + PlayerPrefs.GetInt("bestSeconds" + currentLevel) + ":"   //TODO - Remove when finished testing.
            + PlayerPrefs.GetInt("bestMilliseconds" + currentLevel));   //TODO - Remove when finished testing.
    }

    public void ResetBestTime(string currentLevel)
    {
        PlayerPrefs.SetInt("bestMinutes" + currentLevel, 59);
        PlayerPrefs.SetInt("bestSeconds" + currentLevel, 59);
        PlayerPrefs.SetInt("bestMilliseconds" + currentLevel, 999);
    }

    public bool ReturnBestTime()
    {
        return beatBestTime;
    }

    public TimeSpan ReturnPreviousBestTime()
    {
        return bestTime;
    }
}
