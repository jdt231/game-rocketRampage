using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController3 : MonoBehaviour
{

    int currentState = 1;
    int maxState = 8;// change depending on states required
    public LevelController levelController;

    public Text mainTutorialText;
    public Text backText;
    public Text nextText;

    public Image arrowDeathWall;
    public Image arrowStandard;
    public Image arrowMoving;
    public Image arrowRotating;
    public Image arrowMine;
    public Image arrowLaser;

    public Button leftArrow;
    public Button rightArrow;

    void Start()
    {
        currentState = 1;
        RunTutorial();
    }

    private void RunTutorial()
    {
        if (currentState == 1) { RunStateT3S1(); }
        else if (currentState == 2) { RunStateT3S2(); }
        else if (currentState == 3) { RunStateT3S3(); }
        else if (currentState == 4) { RunStateT3S4(); }
        else if (currentState == 5) { RunStateT3S5(); }
        else if (currentState == 6) { RunStateT3S6(); }
        else if (currentState == 7) { RunStateT3S7(); }
        else if (currentState == 8) { RunStateT3S8(); }
    }

    private void RunStateT3S1()
    {
        DisableArrows();
        mainTutorialText.text = "THERE ARE SEVERAL DIFFERENT OBSTACLES YOU WILL NEED TO AVOID WHILST TRAVERSING THE LEVELS";
    }

    private void RunStateT3S2()
    {
        DisableArrows();
        mainTutorialText.text = "TOUCHING ANYTHING OTHER THAN COLLECTABLES AND THE LANDING PAD AT THE END OF THE LEVEL WILL KILL YOU";
    }

    private void RunStateT3S3()
    {
        DisableArrows();
        arrowStandard.enabled = true;
        mainTutorialText.text = "THERE ARE 3 DIFFERENT TYPES OF BLOCKS. THE YELLOW BLOCKS DON'T MOVE AND MAKE UP MOST OF THE LEVEL";
    }

    private void RunStateT3S4()
    {
        DisableArrows();
        arrowMoving.enabled = true;
        arrowRotating.enabled = true;
        mainTutorialText.text = "THE ORANGE BLOCKS MOVE BACK AND FORTH IN ONE DIRECTION WHILST THE GREEN BLOCKS ROTATE IN PLACE";
    }

    private void RunStateT3S5()
    {
        DisableArrows();
        arrowDeathWall.enabled = true;
        mainTutorialText.text = "THIS IS THE DEATH WALL. ONCE YOU START THE LEVEL THIS WILL START TO SLOWLY MOVE TO THE RIGHT AFTER A TIMED DELAY";
    }

    private void RunStateT3S6()
    {
        DisableArrows();
        arrowLaser.enabled = true;
        mainTutorialText.text = "THIS IS A LASER. IT SWITCHES ON AND OFF PERIODICALLY. THE LENGTH OF TIME IT STAYS ON OR OFF MAY CHANGE PER LEVEL";
    }

    private void RunStateT3S7()
    {
        DisableArrows();
        arrowMine.enabled = true;
        mainTutorialText.text = "THIS IS A MINE. IT WILL BEEP FASTER THE CLOSER YOU GET. GET TOO CLOSE AND IT WILL EXPLODE AFTER A SHORT DELAY. MOVE FAST!";
    }

    private void RunStateT3S8()
    {
        DisableArrows();
        mainTutorialText.text = "THAT COVERS EVERTHING YOU SHOULD NEED TO KNOW TO GET STARTED, GOOD LUCK! PRESS NEXT TO RETURN TO THE MAIN MENU";
    }

    private void DisableArrows()
    {
        arrowDeathWall.enabled = false;
        arrowStandard.enabled = false;
        arrowMoving.enabled = false;
        arrowRotating.enabled = false;
        arrowMine.enabled = false;
        arrowLaser.enabled = false;
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
            levelController.LoadMenuScene();
        }
    }
}
