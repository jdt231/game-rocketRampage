using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    string currentLevel;
    public Button[] levelButtons;

    public void UpdateStarScore(int starsScored)
    {
        currentLevel = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetInt("stars" + currentLevel, starsScored);
    }

    public void ResetAllScores()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            PlayerPrefs.SetInt("stars" + levelButtons[i].name, 0);
        }
        Debug.Log("Resetting Scores"); // TODO - Remove when finished testing.
    }
}
