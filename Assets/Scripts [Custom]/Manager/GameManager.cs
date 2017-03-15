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


public class GameManager : MonoBehaviour
{
    //public Font pauseFont;
    public GameObject pauseMenu;

    public bool isPaused = false;

    public enum STICKHANDEDNESS {
        RIGHT = 0,
        LEFT = 1
    }


    //[SerializeField]
    public STICKHANDEDNESS stickHand;


    public string sceneToLoad;
    //SteamVR_LoadLevel level;

    public static GameManager Instance
    {
        get;
        private set;
    }



    void Awake() {

        // First we check if there are any other instances conflicting
        if (Instance != null && Instance != this)
        {
            // If that is the case, we destroy other instances
            //if (sceneToLoad != SceneManager.GetActiveScene().name)
            Destroy(gameObject);
        }

        // Here we save our singleton instance
        Instance = this;

        // Furthermore we make sure that we don't destroy between scenes (this is optional)
        //if (sceneToLoad != SceneManager.GetActiveScene().name)
        DontDestroyOnLoad(gameObject);
    }


    void Start() {
        isPaused = false;
        SetPauseState(isPaused);
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isPaused = !isPaused;
        }

    }

    public void ChangeStickHand(STICKHANDEDNESS _stick)
    {
        stickHand = _stick;
    }




    public void SwitchScene(string _sceneName, float _time = 0.0f)
    {
        StartCoroutine(ChangeScene(_sceneName, _time));
    }

    IEnumerator ChangeScene(string _sceneName, float _time = 0.0f)
    {
        yield return new WaitForSeconds(_time);
        SceneManager.LoadScene(_sceneName);
    }

    public void SetPauseState(bool _b) {
        isPaused = _b;
        pauseMenu.SetActive(_b);
    }


    //private void OnGUI()
    //{
    //    if (isPaused && (SceneManager.GetActiveScene().name != "MainLobby")) {
    //        int width = 160;
    //        int height = 50;
    //        Vector2 pauseBoxPos;// = new Vector2((Camera.main.pixelWidth / 2) - width/2, (Camera.main.pixelHeight / 2) - height/2);

    //        pauseBoxPos = new Vector2(30, 30);
    //        Vector2 size = new Vector2(width, height);


    //        GUIStyle pauseFontStyle = new GUIStyle(GUI.skin.box);
    //        pauseFontStyle.font = pauseFont;
    //        pauseFontStyle.fontSize = 40;
    //        //pauseFontStyle.alignment = TextAnchor.MiddleCenter;

    //        GUI.color = Color.blue;
    //        GUI.Box(new Rect(pauseBoxPos, size), "PAUSED", pauseFontStyle);
    //    }
    //} 

} // end class GameManager
