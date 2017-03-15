using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassingChallenge : SkillCompetition
{
    public string saucerNetTag = "SaucerNet";

    GameObject[] saucerNets;



    // static singleton instance
    public static PassingChallenge _passingChallenge {
        get;
        private set;
    }

    private void Awake()
    {
        if (_passingChallenge == null)
        {
            _passingChallenge = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }


	// Use this for initialization
	protected override void Start ()
    {

        finalTime = 0.0f;
        
        saucerNets = GameObject.FindGameObjectsWithTag(saucerNetTag);
        ShootPuck(transform.position, transform.forward, 2.0f);
        base.Start();
        RestartGame();
    }


    public override void RestartGame()
    {
        base.RestartGame();
        foreach (GameObject g in saucerNets) {
            SaucerNet sn = g.GetComponent<SaucerNet>();
            sn.isHit = false;
            sn.SetIcon(sn.isHit);
        }
    }


    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (GameManager.Instance.isPaused || !gameStarted || gameOver)
            return;

        SetGameClockText(GameClock.CountdownTimer(skillCompTimer));
    }


    void OnTriggerExit(Collider col)
    {
        base.PuckSpawn(col);
    }

    public override void CheckFinish()
    {
        if (playerScore == saucerNets.Length)
        {
            base.CheckFinish();
            Debug.Log("Your final time is: " + finalTime + " sec");

            GameManager.Instance.SetPauseState(true);
            base.HighScoreCheck();
        }
    }

} // end class PassingChallenge