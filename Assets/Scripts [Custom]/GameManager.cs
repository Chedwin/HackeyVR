//*******************************//
//
// Class Name:		GameManager
// Description:		Global game instance that holds all necessary things for the game.
//
// Author(s):	    Edwin Chen, Andrew Palangio
// Special Thanks:  Name
//
// Created:			Jan 28, 2017
// Last updated:	Mar 01, 2017
//
//*******************************//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SteamVR_LoadLevel))]
public class GameManager : MonoBehaviour
{
    public bool isPaused {
        get;
        private set;
    }

    public enum STICKHANDEDNESS {
        RIGHT = 0,
        LEFT = 1
    }


    //[SerializeField]
    public STICKHANDEDNESS stickHand;


    public string sceneToLoad;
    SteamVR_LoadLevel level;

    public static GameManager Instance
    {
        get;
        private set;
    }



    void Awake() {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyObject(gameObject);
            Start();        
        }
        level = GetComponent<SteamVR_LoadLevel>();

    }
    // this constructor should be prrotected from other classes
    protected GameManager() {
        // empty
    }
    
    void Start() {
        isPaused = false;
        SetPauseState(isPaused);
    }


    public void ChangeStickHand(STICKHANDEDNESS _stick)
    {
        stickHand = _stick;
    }

  


    public void SwitchScene(string _sceneName, float _time = 0.0f) {
        StartCoroutine(ChangeScene(_sceneName, _time));
    }

    IEnumerator ChangeScene(string _sceneName, float _time = 0.0f)
    {
        yield return new WaitForSeconds(_time);

        if (level == null)
            level = GetComponent<SteamVR_LoadLevel>();


        level.levelName = _sceneName;
        level.fadeInTime = 1.0f;
        level.fadeOutTime = 1.0f;
        level.Trigger();
    }

    public void SetPauseState(bool _b) {
        isPaused = _b;
    }

} // end class GameManager
