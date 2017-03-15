//*******************************//
//
// Class Name:		OneTimerChallenge
// Description:		
//
// Author(s):	    Edwin Chen, Andrew Palangio
// Special Thanks:  
//
// Created:			Feb 20, 2017
// Last updated:	Feb 28, 2017
//
//*******************************//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneTimerChallenge : SkillCompetition {

    public GameObject leftCannon;
    public GameObject rightCannon;

    public const int slapShotMinimum = 4;
    const float puckInterval = 3.0f;

    GameObject activeCannon;
    bool canShoot = true;

    public static OneTimerChallenge _oneTimer {
        get;
        private set;
    }

    private void Awake()
    {
        if (_oneTimer == null)
        {
            _oneTimer = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        activeCannon = GetActiveCannon();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        SetGameClockText(GameClock.CountdownTimer(skillCompTimer));

        if (Input.GetKeyUp(KeyCode.Alpha1) && canShoot && (GameManager.Instance.isPaused == false) && (gameOver == false)) {

            if (!gameStarted)
                gameStarted = true;

            FirePuckFromCannon();
            canShoot = false;
            StartCoroutine(ShotTimer(puckInterval));
        }

    }

    GameObject GetActiveCannon() {
        if (GameManager.Instance.stickHand == GameManager.STICKHANDEDNESS.LEFT)
        {
            leftCannon.SetActive(true);
            rightCannon.SetActive(false);
            return leftCannon;
        }
        else
        {
            leftCannon.SetActive(false);
            rightCannon.SetActive(true);
            return rightCannon;
        }
    }

    IEnumerator ShotTimer(float _time)
    {
        yield return new WaitForSeconds(_time);
        canShoot = true;
    }
    

    public void FirePuckFromCannon()
    {
        Transform pos = activeCannon.transform.FindChild("PCshooter");
        ShootPuck(pos.position, pos.forward, 0.5f, 40.0f);
        shotCount++;
        SetShotCountText(shotCount);
            
    }

    public override void CheckFinish()
    {
        if (playerScore == slapShotMinimum) {

            base.CheckFinish();
            Debug.Log("Your finish time is: " + finalTime + " sec");

            GameManager.Instance.SetPauseState(true);
            base.HighScoreCheck();
        }
    }

} // end class SkillCompetion
