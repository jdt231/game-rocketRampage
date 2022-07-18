using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController1 : MonoBehaviour
{
    string currentLevel;
    public Button[] levelButtons;

    public void PrintStarScores()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            Debug.Log("Stars earned in " + levelButtons[i].name + " is " + PlayerPrefs.GetInt("stars" + levelButtons[i].name));
        }
    }

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
    }
}
