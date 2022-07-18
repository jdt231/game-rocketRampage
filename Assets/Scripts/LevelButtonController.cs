using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    [SerializeField] Image firstStar;
    [SerializeField] Image secondStar;
    [SerializeField] Image thirdStar;
    [SerializeField] Text levelButtonText;
    [SerializeField] Text bestTimeText;

    Color32 ActiveColor = new Color32(255, 255, 0, 255);

    int currentScore;
    public int minimumMedalsRequired = 0;

    void Start()
    {
        currentScore = PlayerPrefs.GetInt("stars" + gameObject.name, 0);
        UpdateButtons();
        //UpdateText();
    }

    public void UpdateButtons()
    {
        if (currentScore <= 0) { return; }

        else if (currentScore == 1)
        {
            firstStar.color = ActiveColor;
        }
        else if (currentScore == 2)
        {
            firstStar.color = ActiveColor;
            secondStar.color = ActiveColor;
        }

        else if (currentScore >= 3)
        {
            firstStar.color = ActiveColor;
            secondStar.color = ActiveColor;
            thirdStar.color = ActiveColor;
        }
    }

    public void UpdateText()
    {
        int bestMinutes = PlayerPrefs.GetInt("bestMinutes" + gameObject.name, 59); // Set initial time to beat: 59m:59s:99mm.
        int bestSeconds = PlayerPrefs.GetInt("bestSeconds" + gameObject.name, 59);
        int bestMilliseconds = PlayerPrefs.GetInt("bestMilliseconds" + gameObject.name, 99);

        TimeSpan bestTime = new TimeSpan(0, 0, bestMinutes, bestSeconds, bestMilliseconds);

        bestTimeText.text = "Best Time: " + bestTime.ToString("mm':'ss'.'ff");
    }

    public void SetButtonInactive()
    {
        firstStar.enabled = false;
        secondStar.enabled = false;
        thirdStar.enabled = false;
        bestTimeText.alignment = TextAnchor.MiddleCenter;
        bestTimeText.fontSize = 55;
        bestTimeText.text = "MEDALS REQUIRED:";
        levelButtonText.alignment = TextAnchor.LowerCenter;
        levelButtonText.text = minimumMedalsRequired.ToString();
    }
}
