using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLobbySkillMenu : MonoBehaviour {

    public void EnterFreeMode()
    {
        GameManager.Instance.SwitchScene("FreeMode");
    }

    public void EnterPassingChallenge()
    {
        GameManager.Instance.SwitchScene("PassingChallenge");
    }

    public void EnterShootingAccuracy()
    {
        GameManager.Instance.SwitchScene("ShootingAccuracy");

    }

    public void EnterPuckProtection()
    {
        GameManager.Instance.SwitchScene("PuckProtection");
    }

    public void EnterOneTimer()
    {
        GameManager.Instance.SwitchScene("OneTimer");
    }


} // end class MainLobbySkillMenu
