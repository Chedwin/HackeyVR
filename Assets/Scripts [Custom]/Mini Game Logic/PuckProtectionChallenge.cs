//*******************************//
//
// Class Name:		PuckProtectionChallenge
// Description:		
//
// Author(s):	    Edwin Chen, Andrew Palangio
// Special Thanks:  
//
// Created:			Jan 27, 2017
// Last updated:	Feb 22, 2017
//
//*******************************//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuckProtectionChallenge : SkillCompetition
{
    public GameObject[] cannons;
    public GameObject playerPuck;

    public Transform playPuckSpawnPoint;

    int shotsFired = 0;
    public Text awayText;
    public bool inPossession = false;

    public float shootSpeed = 60.0f;
    public const float waveInterval = 30.0f;

    float puckTimer = 0.0f;

    int currentWave = 1;
    float infimum = 1.5f;
    float supremum = 2.0f;

    public int puckstickHit = 0;
    public int maxPuckHit = 3;


    // static singleton instance
    public static PuckProtectionChallenge _puckProtection {
        get;
        private set;
    }

    void Awake()
    {
        if (_puckProtection == null)
        {
            _puckProtection = this;
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
        puckTimer = 0.0f;
        cannons = GameObject.FindGameObjectsWithTag("Cannon");
        awayText.text = currentWave.ToString();
        SetShotCountText(shotsFired);
        puckstickHit = 0;

        StartCoroutine(SpawnPlayerPuck());
        //sfx = new Dictionary<string, AudioClip>();

        
    }


    IEnumerator SpawnPlayerPuck() {
        playerPuck.SetActive(false);
        yield return new WaitForSeconds(3.0f);
        playerPuck.SetActive(true);
        playerPuck.transform.position = playPuckSpawnPoint.position;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (!inPossession || !gameStarted || GameManager.Instance.isPaused || gameOver)
            return;
 
        base.Update();

        SetGameClockText(GameClock.CountdownTimer(skillCompTimer));

        puckTimer += Time.deltaTime;

        
        FirePuckCannon(Random.Range(0, cannons.Length), infimum, supremum);
        IncrementSpeed(skillCompTimer, 10.0f);
    }

    void FirePuckCannon(int _cannonIndex, float _lowerBound = 2.0f, float _upperBound = 3.0f)
    {
        if (puckTimer >= Random.Range(_lowerBound, _upperBound))
        {
            PuckCannon puckCannon = cannons[_cannonIndex].GetComponent<PuckCannon>();
            puckCannon.FireCannon();

            puckTimer = 0.0f;
            shotsFired++;
            SetShotCountText(shotsFired);
        }

    }

    void IncrementSpeed(float _t, float _interval) {
        float f = _t % _interval;
        bool inRange = f.InRange<float>(0.0f, 0.01f);

        if (inRange)
        {
            foreach (GameObject i in cannons)
            {
                PuckCannon p = i.GetComponent<PuckCannon>();
                p.shootSpeed += 1.0f;
            }

            currentWave++;
            infimum -= 0.1f;
            supremum -= 0.1f;

            if (infimum <= 0.2f)
                infimum = 0.2f;

            if (supremum <= 0.4f)
                supremum = 0.4f;

            awayText.text = currentWave.ToString();
        }
    }

    public override void CheckFinish()
    {
        base.CheckFinish();
        Debug.Log("You survived for: " + finalTime + " sec");

        GameManager.Instance.SetPauseState(true);
        HighScore high = GetComponent<HighScore>();

        if (playerScore > high.GetHighScore())
        {
            high.SaveHighScore(playerScore);
            awayScore.text = "New High Score!";
            high.DisplayHighScore();
        }
    }


} // end class PuckProtectionChallenge
