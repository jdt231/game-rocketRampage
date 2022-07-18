using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameController gameController;
    public TimerController timerController;
    Color32 ActiveColor = new Color32(255, 255, 0, 255);

    [Header("Level Complete UI")]
    public Text collectablesText;
    public Text targetTimeText;
    public Text actualTimeText;
    public Image medal1;
    public Image medal2;
    public Image medal3;
    public Text previousBestTimeText;
    public Text newBestTimeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLevelCompleteUI()
    {
        newBestTimeText.enabled = false;
        collectablesText.text = gameController.currentCollectables + ":" + gameController.maxCollectables;
        targetTimeText.text = gameController.timeTarget.ToString("mm':'ss'.'ff");
        string actualTime = timerController.timePlaying.ToString("mm':'ss'.'ff");
        actualTimeText.text = actualTime;
        UpdateMedalCountUI();
        UpdatePreviousBestTime();
        if (!timerController.beatBestTime) { return; }
        else
        {
            newBestTimeText.enabled = true;
            newBestTimeText.text = "NEW BEST TIME:   " + actualTime;
        }
    }

    private void UpdatePreviousBestTime()
    {
        //string currentLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        //int bestMinutes = PlayerPrefs.GetInt("bestMinutes" + currentLevel, 59); // Set initial time to beat: 99m:99s:99mm.
        //int bestSeconds = PlayerPrefs.GetInt("bestSeconds" + currentLevel, 59);
        //int bestMilliseconds = PlayerPrefs.GetInt("bestMilliseconds" + currentLevel, 99);

        TimeSpan previousBestTime = timerController.ReturnPreviousBestTime();
        previousBestTimeText.text = previousBestTime.ToString("mm':'ss'.'ff");
    }

    private void UpdateMedalCountUI()
    {
        int medalScore = gameController.medalScore;
        if (medalScore == 0) { return; }
        else if (medalScore == 1)
        {
            medal1.color = ActiveColor;
        }
        else if (medalScore == 2)
        {
            medal1.color = ActiveColor;
            medal2.color = ActiveColor;
        }

        else if (medalScore >= 3)
        {
            medal1.color = ActiveColor;
            medal2.color = ActiveColor;
            medal3.color = ActiveColor;
        }
    }
}
