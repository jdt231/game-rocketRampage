using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController2 : MonoBehaviour
{
    int currentState = 1;
    int maxState = 5;// change depending on states required
    public LevelController levelController;

    public Text mainTutorialText;
    public Text backText;
    public Text nextText;

    public Image arrowThrust;
    public Image arrowPause;
    public Image arrowRotateRight;
    public Image arrowRotateLeft;
    public Image arrowTime;
    public Image arrowTargetTime;
    public Image arrowCollectables;

    public Button leftArrow;
    public Button rightArrow;

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0f;
        currentState = 1;
        RunTutorial();
    }

    private void RunTutorial()
    {
        //if (currentState == 0){ leftArrow.interactable = false; backText.enabled = false; }
        //else { leftArrow.interactable = true; backText.enabled = true; }
        
        if (currentState == 1) { RunStateT1S1(); }
        else if (currentState == 2) { RunStateT1S2(); }
        else if (currentState == 3) { RunStateT1S3(); }
        else if (currentState == 4) { RunStateT1S4(); }
        else if (currentState == 5) { RunStateT1S5(); }
    }

    private void RunStateT1S1()
    {
        DisableArrows();
        arrowThrust.enabled = true;
        mainTutorialText.text = "USE THE UP ARROW BUTTON TO APPLY THRUST TO THE ROCKET IN THE DIRECTION IT IS FACING";
    }

    private void RunStateT1S2()
    {
        DisableArrows();
        arrowRotateLeft.enabled = true;
        arrowRotateRight.enabled = true;
        mainTutorialText.text = "USE THE LEFT AND RIGHT ARROW BUTTONS TO ROTATE THE ROCKET IN THAT DIRECTION";
    }

    private void RunStateT1S3()
    {
        DisableArrows();
        arrowTargetTime.enabled = true;
        arrowTime.enabled = true;
        mainTutorialText.text = "EACH LEVEL HAS A TARGET TIME TO FINISH UNDER, YOU CAN ALSO SEE YOUR CURRENT TIME HERE";
    }

    private void RunStateT1S4()
    {
        DisableArrows();
        arrowCollectables.enabled = true;
        mainTutorialText.text = "YOU CAN SEE HOW MANY COLLECTABLES ARE IN THE LEVEL AND HOW MANY YOU HAVE FOUND HERE";
    }

    private void RunStateT1S5()
    {
        DisableArrows();
        arrowPause.enabled = true;
        mainTutorialText.text = "THIS BUTTON WILL PAUSE THE GAME. YOU CAN RESTART THE LEVEL, ADJUST THE VOLUME OR QUIT FROM THERE";
    }

    private void DisableArrows()
    {
        arrowThrust.enabled = false;
        arrowPause.enabled = false;
        arrowRotateRight.enabled = false;
        arrowRotateLeft.enabled = false;
        arrowTime.enabled = false;
        arrowTargetTime.enabled = false;
        arrowCollectables.enabled = false;
    }

    public void DecreaseState()
    {
        if (currentState > 0)
        {
            currentState = currentState - 1;
            RunTutorial();
        }

        else if (currentState == 0)
        {
            levelController.LoadPreviousScene();
        }

    }

    public void IncreaseState()
    {
        if (currentState < maxState)
        {
            currentState = currentState + 1;
            RunTutorial();
        }
        else if (currentState >= maxState)
        {
            levelController.LoadNextScene();
        }

    }
}
