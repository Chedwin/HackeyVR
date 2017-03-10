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
        base.Start(); 

        finalTime = 0.0f;
        
        saucerNets = GameObject.FindGameObjectsWithTag(saucerNetTag);
        Debug.Log(saucerNets.Length);
        ShootPuck(transform.position, transform.forward, 2.0f);
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
        Debug.Log(playerScore);
        if (playerScore == saucerNets.Length)
        {
            base.CheckFinish();
            Debug.Log("Your final time is: " + finalTime + " sec");

            //ScoreEntry r = new ScoreEntry();
            //r.name = "AAA";
            //r.score = playerScore;
            GameManager.Instance.SetPauseState(true);
            HighScore high = GetComponent<HighScore>();

            if (playerScore < high.GetHighScore())
            {
                high.SaveHighScore(playerScore);
                awayScore.text = "New High Score!";
                high.DisplayHighScore();
            }
        }
    }

} // end class PassingChallenge