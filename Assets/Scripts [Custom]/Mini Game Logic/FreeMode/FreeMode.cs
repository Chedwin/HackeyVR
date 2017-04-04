//*******************************//
//
// Class Name:		FreeMode
// Description:		A basic description of the header goes here.
//
// Author(s):	    Edwin Chen, Andrew Palangio
// Special Thanks:  
//
// Created:			Jan 27, 2017
// Last updated:	Feb 28, 2017
//
//*******************************//

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeMode : SkillCompetition
{
    public int backNetScore = 0;

    public GoalLight backLight;

    // static singleton instance
    public static FreeMode _freeMode {
        get;
        private set;
    }

    protected FreeMode() { }

    void Awake()
    {
        if (_freeMode == null)
        {
            _freeMode = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }

    protected override void Start()
    {
        base.Start();
        gameStarted = true;
        backNetScore = 0;
        awayScore.text = backNetScore.ToString();
    }

    // Update is called once per frame
    protected override void Update ()
    {
        base.Update();
        SetGameClockText(GameClock.DigitalTimeConvert(skillCompTimer));
    }


    public void HomeScore()
    {
        playerScore++;
        SetHomeScoreText(playerScore);
        SoundGoalLight();
        AudioManager.Instance.PlayClip("goalHorn");
        CrowdManager.Instance.AllCheer();
    }

    public void VisitorScore()
    {
        Debug.Log("Visiotototo");
        backNetScore++;
        awayScore.text = backNetScore.ToString();
        SoundVisitorGoalLight();
        AudioManager.Instance.PlayClip("airHorn");
        CrowdManager.Instance.AllBoo();
    }

    public void SoundVisitorGoalLight(float _time = 2.0f)
    {
        StartCoroutine(backLight.SoundGoalLight(2.0f));
    }

} // end class FreeMode