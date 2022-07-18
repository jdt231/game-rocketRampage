using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody myRigidbody;
    AudioSource audioSource;
    public AudioSource thrusterAudio;

    public DeathWallController deathWall;
    public GameController gameController;
    public LevelController levelController;
    public TimerController timerController;
    public UIController uIController;

    Laser[] lasers;
    Mine[] mines;

    public bool isAlive = false;
    public bool collisionEnabled = true;

    //[SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 500f;

    [Header("Audio")]
    [SerializeField] AudioClip engineSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip successSound;

    [Header("Particles")]
    [SerializeField] ParticleSystem engineParticles;
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] ParticleSystem successParticles;

    public ButtonPressed rotateLeftButton;
    public ButtonPressed rotateRightButton;
    public ButtonPressed thrustButton;

    void Start()
    {
        //rcsThrust = (PlayerPrefsController.GetShipSensitivity() * 100 / 2);
        myRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        lasers = FindObjectsOfType<Laser>();
        mines = FindObjectsOfType<Mine>();
        thrusterAudio.mute = true;
        thrusterAudio.Play();
    }

    void Update()
    {
        if(isAlive == true)
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isAlive == false || !collisionEnabled) { return; }

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                // do nothing
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartDyingSequence();
                break;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (isAlive == false || !collisionEnabled) { return; }
        else 
        {
            StartDyingSequence();
        }
    }

    public void StartSuccessSequence()
    {
        StopLevel();
        audioSource.volume = PlayerPrefsController.GetOtherVolume();
        audioSource.PlayOneShot(successSound);
        successParticles.Play();
        levelController.UpdateLevelsUnlocked();
        timerController.ManageBestTime();
        gameController.CalculateStarsScored();
        gameController.TriggerWinScreen();
        uIController.UpdateLevelCompleteUI();
    }

    private void StartDyingSequence()
    {
        StopLevel();
        gameController.TriggerLoseScreen();
        audioSource.volume = PlayerPrefsController.GetOtherVolume();
        audioSource.PlayOneShot(deathSound);
        deathParticles.Play();
    }

    private void StopLevel()
    {
        isAlive = false;
        thrusterAudio.mute = true;
        engineParticles.Stop();
        DisableEnemies();
    }

    private void DisableEnemies()
    {
        deathWall.levelOver = true;

        foreach (Laser laser in lasers)
        {
            laser.TurnOffLaser();
        }
        foreach (Mine mine in mines)
        {
            mine.TurnOffMine();
        }
    }

    private void RespondToThrustInput()
    {
        if ((Input.GetKey(KeyCode.Space) || thrustButton.buttonPressed == true) && gameController.paused == false)
        {
            ApplyThrust();
        }
        else
        {
            thrusterAudio.mute = true;
            engineParticles.Stop();
        }
    }

    private void ApplyThrust()
    {
        float thrustThisFrame = mainThrust * Time.deltaTime;

        myRigidbody.AddRelativeForce(Vector3.up * thrustThisFrame);
        thrusterAudio.volume = PlayerPrefsController.GetOtherVolume();
        thrusterAudio.mute = false;
        engineParticles.Play();
    }

    private void RespondToRotateInput()
    {
        myRigidbody.freezeRotation = true; //take manual control of rotation.

        //float rotationThisFrame = rcsThrust * Time.deltaTime;
        float rotationThisFrame = 250 * Time.deltaTime; // DELETE AND RESTORE ABOVE WHEN DONE TESTING

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || rotateLeftButton.buttonPressed == true) 
            && gameController.paused == false)
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || rotateRightButton.buttonPressed == true) 
            && gameController.paused == false)
        {
            transform.Rotate(Vector3.back * rotationThisFrame);
        }

        myRigidbody.freezeRotation = false; // resume physics control of rotation.
    }

    public void ToggleCollisions()
    {
        collisionEnabled = !collisionEnabled;
    }

}
