using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingAccuracyChallenge : SkillCompetition
{
    GameObject[] targets;
    public string targetPadTag = "TargetPad";

    //public float finalTime = 0.0f;

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
        targets = GameObject.FindGameObjectsWithTag(targetPadTag);

        ShootPuck(transform.position, transform.forward, 2.0f);
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

    public override void CheckFinish()
    {
        if (playerScore == targets.Length)
        {
            base.CheckFinish();
            Debug.Log("Your final time is: " + skillCompTimer + " sec");
        }
    }

} // end class ShootingAccuracyChallenge