using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class PauseMenuController : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    //public GameObject pauseMenu;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    GameManager gameManager {
        get { return GameManager.Instance; }
    }

    AudioManager audioGame {
        get { return AudioManager.Instance; }
    }

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }


    void Update()
    {
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip) || Input.GetKeyUp(KeyCode.Space))
            TogglePause();
    }



    void TogglePause()
    {
        gameManager.SetPauseState(!gameManager.isPaused);

        if (gameManager.isPaused)
            audioGame.PlayClip("doubleWhistle");
        else
            audioGame.PlayClip("whistle");
    }
} // end class PauseMenuController
