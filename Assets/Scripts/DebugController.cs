using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour
{
    public Rocket rocket;
    public LevelController levelController;
    public DeathWallController deathWall;

    public Text collisionsButtonText;
    public Text deathWallButtonText;

    void Update()
    {
        //if (Debug.isDebugBuild)
        {
            
        }
        RespondToDebugKeys(); // Moved outside of if statement as Development build file size much larger than standard.
    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            levelController.LoadNextScene();
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleRocketCollisions();
        }

        else if (Input.GetKeyDown(KeyCode.Z))
        {
            ToggleWallMoving();
        }

        else if (Input.GetKeyDown(KeyCode.V))
        {
            rocket.StartSuccessSequence();
        }
    }

    public void ToggleWallMoving()
    {
        deathWall.ToggleIsActive();
    }

    public void ToggleRocketCollisions()
    { 
        rocket.ToggleCollisions();
    }

    public void UpdateDebugText()
    {
        //UpdateCollisionsText();
        //UpdateDeathWallText();
        Debug.LogWarning("The 'UpdateDebugText' method is being called from the DebugController. It should not be");
    }

    private void UpdateDeathWallText() // Not being used, remove once sure it is no longer needed
    {
        if (deathWall.isActive == true)
        {
            deathWallButtonText.text = ("on");
        }
        else if (deathWall.isActive == false)
        {
            deathWallButtonText.text = ("off");
        }
    }

    private void UpdateCollisionsText() // Not being used, remove once sure it is no longer needed
    {
        if (rocket.collisionEnabled == true)
        {
            collisionsButtonText.text = ("on");
        }
        else if (rocket.collisionEnabled == false)
        {
            collisionsButtonText.text = ("off");
        }
    }
}
