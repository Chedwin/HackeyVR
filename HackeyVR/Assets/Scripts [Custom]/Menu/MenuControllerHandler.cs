using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerHandler : MonoBehaviour {

   
    public void QuitGame()
    {
        if (!GameManager.Instance.isPaused)
            return;

        if (SceneManager.GetActiveScene().name == "MainLobby")
        {
            
        }
        else
        {
            GameManager.Instance.SwitchScene("MainLobby", 1.0f);
        }
    }

    public void RestartGame()
    {
        if (!GameManager.Instance.isPaused)
            return;

        GameManager.Instance.SwitchScene(SceneManager.GetActiveScene().name, 1.0f);
    }


    public void LeftStick()
    {
        if (!GameManager.Instance.isPaused)
            return;

        if (GameManager.Instance.stickHand == GameManager.STICKHANDEDNESS.LEFT)
            return;

        GameManager.Instance.ChangeStickHand(GameManager.STICKHANDEDNESS.LEFT);

        StickMenu stick = transform.FindChild("StickHandMenu").GetComponent<StickMenu>();
        stick.ChangeMenuColor();

        GameManager.Instance.SetPauseState(false);
        GameManager.Instance.SwitchScene(SceneManager.GetActiveScene().name, 1.0f);
    }

    public void RightStick()
    {
        if (!GameManager.Instance.isPaused)
            return;

        if (GameManager.Instance.stickHand == GameManager.STICKHANDEDNESS.RIGHT)
            return;

        GameManager.Instance.ChangeStickHand(GameManager.STICKHANDEDNESS.RIGHT);

        StickMenu stick = transform.FindChild("StickHandMenu").GetComponent<StickMenu>();
        stick.ChangeMenuColor();

        GameManager.Instance.SetPauseState(false);
        GameManager.Instance.SwitchScene(SceneManager.GetActiveScene().name, 1.0f);
    }



} // end class MenuControllerHandler
