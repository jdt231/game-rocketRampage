using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallController : MonoBehaviour
{
    public bool isActive = true;
    public bool levelOver = false;
    public bool isMoving = false;
    public float wallMovementSpeed = 10f;
    public float wallMovementDelay = 3f;

    void Update()
    {
        if (isActive && isMoving && !levelOver)
        {
            transform.Translate(wallMovementSpeed * Time.deltaTime, 0, 0);
        }
    }

    IEnumerator StartWallMoving() //Being called by the GameController
    {
        yield return new WaitForSeconds(wallMovementDelay);
        isMoving = true;
    }

    public void ToggleIsActive()
    {
        isActive = !isActive;
    }
}
