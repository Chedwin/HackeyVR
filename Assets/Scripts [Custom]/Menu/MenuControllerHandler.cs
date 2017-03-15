using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerHandler : MonoBehaviour {

    HockeyStickController hckStick;
    public GameObject rightHand;
    SkillCompetition skillRef;

    void Start()
    {
        hckStick = rightHand.GetComponent<HockeyStickController>();
        skillRef = SkillCompetition.GetSkillRef();
    }

    public void QuitGame()
    {
        //if (!GameManager.Instance.isPaused)
        //    return;

        if (SceneManager.GetActiveScene().name != "MainLobby")
            GameManager.Instance.SwitchScene("MainLobby", 1.0f);
    }

    public void RestartGame()
    {
        //if (!GameManager.Instance.isPaused)
        //    return;
        skillRef.RestartGame();
    }


    public void LeftStick()
    {
        if (GameManager.Instance.stickHand == GameManager.STICKHANDEDNESS.LEFT)
            return;

        GameManager.Instance.ChangeStickHand(GameManager.STICKHANDEDNESS.LEFT);

        StickMenu stick = transform.FindChild("StickHandMenu").GetComponent<StickMenu>();
        stick.ChangeMenuColor();

        GameManager.Instance.SetPauseState(false);


        hckStick.AttachStick(GameManager.Instance.stickHand);
        RestartGame();
    }

    public void RightStick()
    {
        if (GameManager.Instance.stickHand == GameManager.STICKHANDEDNESS.RIGHT)
            return;

        GameManager.Instance.ChangeStickHand(GameManager.STICKHANDEDNESS.RIGHT);

        StickMenu stick = transform.FindChild("StickHandMenu").GetComponent<StickMenu>();
        stick.ChangeMenuColor();

        GameManager.Instance.SetPauseState(false);

        hckStick.AttachStick(GameManager.Instance.stickHand);
        RestartGame();
    }



} // end class MenuControllerHandler
