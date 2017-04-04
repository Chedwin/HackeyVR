using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingAccuracyChallenge : SkillCompetition
{
    public GameObject targetPad;

    public TargetPad[] targets;

    // static singleton instance
    public static ShootingAccuracyChallenge _shootingAccuracy {
        get;
        private set;
    }


    void Awake()
    {
        if (_shootingAccuracy == null)
        {
            _shootingAccuracy = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }


    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        targets = GameObject.FindObjectsOfType<TargetPad>();
        RestartGame();

        ShootPuck(transform.position, transform.forward, 2.0f);
    }

    public override void RestartGame()
    {
        base.RestartGame();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        SetGameClockText(GameClock.CountdownTimer(skillCompTimer));
    }

    void OnTriggerExit(Collider col)
    {
        PuckSpawn(col);
    }

    public void HitTargetPad()
    {
        playerScore++;
        SetHomeScoreText(playerScore);
        SoundGoalLight();
        AudioManager.Instance.PlayClip("goalHorn");
        CheckFinish();
    }

    public override void CheckFinish()
    {
        if (playerScore == targets.Length)
        {
            base.CheckFinish();
            Debug.Log("Your final time is: " + skillCompTimer + " sec");
            SoundGoalLight(10.0f);
            base.HighScoreCheck();
        }
    }

} // end class ShootingAccuracyChallenge