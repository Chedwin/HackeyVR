using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobbySkillMenu : MonoBehaviour {




    const string loadScene = "LoadingScene";

    public void EnterFreeMode()
    {
        GameManager.Instance.sceneToLoad = "FreeMode";
        GameManager.Instance.SwitchScene(GameManager.Instance.sceneToLoad);
    }

    public void EnterPassingChallenge()
    {
        GameManager.Instance.sceneToLoad = "PassingChallenge";
        GameManager.Instance.SwitchScene(GameManager.Instance.sceneToLoad);
    }

    public void EnterShootingAccuracy()
    {
        GameManager.Instance.sceneToLoad = "ShootingAccuracy";
        GameManager.Instance.SwitchScene(GameManager.Instance.sceneToLoad);
        
    }

    public void EnterPuckProtection()
    {
        GameManager.Instance.sceneToLoad = "PuckProtection";
        GameManager.Instance.SwitchScene(GameManager.Instance.sceneToLoad);
    }

    public void EnterOneTimer()
    {
        GameManager.Instance.sceneToLoad = "OneTimer";
        GameManager.Instance.SwitchScene(GameManager.Instance.sceneToLoad);
    }


} // end class MainLobbySkillMenu
