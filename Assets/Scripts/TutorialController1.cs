using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController1 : MonoBehaviour
{
    int currentState = 1;
    int maxState = 7; // change depending on states required
    public LevelController levelController;

    public Text mainTutorialText;
    public Text backText;
    public Text nextText;

    public Image arrowRocket;
    public Image arrowPad;
    public Image arrowCollectable1;
    public Image arrowCollectable2;

    public Button leftArrow;
    public Button rightArrow;

    void Start()
    {
        //Time.timeScale = 0f; // REMOVE ONCE CONFIRMED IS NO LONGER NEEDED.
        currentState = 1;
        RunTutorial();
    }

    private void RunTutorial()
    {
        print("the current state is: " + currentState);
        if (currentState == 0) { leftArrow.interactable = false; backText.enabled = false; }
        else { leftArrow.interactable = true; backText.enabled = true; }

        if (currentState == 1) { RunStateT2S1(); }
        else if (currentState == 2) { RunStateT2S2(); }
        else if (currentState == 3) { RunStateT2S3(); }
        else if (currentState == 4) { RunStateT2S4(); }
        else if (currentState == 5) { RunStateT2S5(); }
        else if (currentState == 6) { RunStateT2S6(); }
        else if (currentState == 7) { RunStateT2S7(); }
    }

    private void RunStateT2S1()
    {
        DisableArrows();
        arrowRocket.enabled = true;
        mainTutorialText.text = "WELCOME TO ROCKET RAMPAGE. THIS HERE IS YOUR ROCKET";
    }

    private void RunStateT2S2()
    {
        DisableArrows();
        arrowPad.enabled = true;
        mainTutorialText.text = "THE GOAL OF EACH LEVEL IS TO NAVIGATE THE ROCKET THROUGH THE COURSE AND TOUCH THIS LANDING PAD";
    }

    private void RunStateT2S3()
    {
        DisableArrows();
        arrowCollectable1.enabled = true;
        arrowCollectable2.enabled = true;
        mainTutorialText.text = "THERE ARE ALSO THESE COLLECTABLES TO BE FOUND. TOUCHING THEM WITH THE ROCKET WILL COLLECT THEM";
    }

    private void RunStateT2S4()
    {
        DisableArrows();
        mainTutorialText.text = "IN EACH LEVEL YOU CAN EARN 3 MEDALS FOR COMPLETING 3 DIFFERENT TASKS.";
    }

    private void RunStateT2S5()
    {
        DisableArrows();
        mainTutorialText.text = "HOWEVER, EACH TASK MUST BE COMPLETED IN THE SAME ATTEMPT TO EARN MULTIPLE MEDALS. THESE TASKS ARE:";
    }

    private void RunStateT2S6()
    {
        DisableArrows();
        mainTutorialText.text = "1.FINISH THE LEVEL\n2.FINISH WITHIN THE TARGET TIME\n3.COLLECT ALL THE COLLECTABLES";
    }

    private void RunStateT2S7()
    {
        DisableArrows();
        mainTutorialText.text = "HIGHER LEVELS REQUIRE A CERTAIN NUMBER OF TOTAL MEDALS EARNED TO UNLOCK. EARN MORE MEDALS TO UNLOCK MORE LEVELS!";
    }

    private void DisableArrows()
    {
        arrowRocket.enabled = false;
        arrowPad.enabled = false;
        arrowCollectable1.enabled = false;
        arrowCollectable2.enabled = false;
    }

    public void DecreaseState()
    {
        if (currentState > 0)
        {
            currentState = currentState - 1;
        }
        print(currentState);
        RunTutorial();
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
