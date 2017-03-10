using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class PauseMenuController : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    public GameObject pauseMenu;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }



    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        if (GameManager.Instance.isPaused)
        {
            //panel.SetActive(true);
            pauseMenu.SetActive(true);
        }
        else
        {
            //panel.SetActive(false);
            pauseMenu.SetActive(false);
        }
    }


    void Update()
    {
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            GameManager.Instance.SetPauseState(!GameManager.Instance.isPaused);
            Debug.Log("Paused: " + GameManager.Instance.isPaused);
            pauseMenu.SetActive(GameManager.Instance.isPaused);
        }
    }

} // end class PauseMenuController
