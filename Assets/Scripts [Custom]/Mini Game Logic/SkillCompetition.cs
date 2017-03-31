//*******************************//
//
// Class Name:		SkillCompetition
// Description:		Abstract base class for separate mini games to derive from.
//
// Author(s):	    Edwin Chen
// Special Thanks:  
//
// Created:			Jan 28, 2017
// Last updated:	Mar 31, 2017
//
//*******************************//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SkillCompetition : MonoBehaviour
{
    #region Fields
    protected float skillCompTimer;


    public Text scoreClock;

    public int playerScore = 0;
    public Text playerScoreText;

    public Text awayScore;

    public Text shotCounterText;

    public float finalTime = 0.0f;

    [SerializeField]
    public bool gameStarted {
        get;
        set;
    }


    public GameObject puck;
    public GameObject ball;

    public int shotCount = 0;

    [SerializeField]
    public bool gameOver = false;

    public bool startDestroyPuck = false;
    #endregion

    ////////////////////////////////////////////////////////////////////

    #region Methods

    // Start logic here
    protected virtual void Start() {
        RestartGame();
    }

    public virtual void RestartGame()
    {
        GameManager.Instance.SetPauseState(false);
        gameStarted = false;
        gameOver = false;
        skillCompTimer = 0;
        shotCount = 0;
        playerScore = 0;
        awayScore.text = "";
        SetGameClockText("00:00");
        SetHomeScoreText(playerScore);
        SetShotCountText(shotCount);
        
        AudioManager.Instance.PlayClip("whistle");
    }

    // Update logic here
    protected virtual void Update() {
        if (GameManager.Instance.isPaused == false && gameStarted && !gameOver) {
            skillCompTimer += Time.deltaTime;
            SetGameClockText(GameClock.CountdownTimer(skillCompTimer));
        }

    }

    // Game clock
    public void SetGameClockText(string _t) {
        scoreClock.text = _t;
    }
    public void SetGameClockText(float _t)
    {
        scoreClock.text = _t.ToString();
    }

    // player (home) score
    public void SetHomeScoreText(int _t)
    {
        playerScoreText.text = _t.ToString();
    }

    // shot counter
    public void SetShotCountText(int _c)
    {
        shotCounterText.text = _c.ToString();
    }


    public void ShootPuck(Vector3 _spawnPt, Vector3 _dir, float _delayTime = 0.0f, float _shootSpeed = 0.0f)
    {
        StartCoroutine(CoroutinePuck(_spawnPt, _dir, _delayTime, _shootSpeed));
    }

    IEnumerator CoroutinePuck(Vector3 _spawnPt, Vector3 _dir, float _delayTime = 0.0f, float _shootSpeed = 0.0f) {

        yield return new WaitForSeconds(_delayTime);
        GameObject newPuck = Instantiate(puck, _spawnPt, Quaternion.identity) as GameObject;

        Rigidbody rb = newPuck.GetComponent<Rigidbody>();
        rb.AddForce(_dir * _shootSpeed, ForceMode.Impulse);

        if (startDestroyPuck) {
            Projectile p = newPuck.GetComponent<Projectile>();
            p.StartCoroutine(p.DestroyPuck());
        }
    }

    protected void PuckSpawn(Collider col)
    {
        if (col.gameObject.tag != "Puck" || GameManager.Instance.isPaused)
            return;

        if (!gameStarted)
            gameStarted = true;

        Projectile proj = col.gameObject.GetComponent<Projectile>();
        if (proj.shot)
            return;

        proj.shot = true;
        StartCoroutine(proj.DestroyPuck());


        ShootPuck(transform.position, transform.forward, 2.0f);
        shotCount++;
        SetShotCountText(shotCount);
    }


    public virtual void CheckFinish()
    {
        finalTime = skillCompTimer;
        gameStarted = false;
        gameOver = true;

        AudioManager.Instance.PlayClip("periodBuzzer");
    }

    public virtual void HighScoreCheck()
    {
        HighScore high = GetComponent<HighScore>();

        if (skillCompTimer < high.GetHighScore())
        {
            high.SaveHighScore(skillCompTimer);
            awayScore.text = "New High Score!";
            high.DisplayHighScore();
        }
    }


    ///  kind of gross but probably could be fixed later
    public static SkillCompetition GetSkillRef()
    { 
        SkillCompetition skillRef;

        if (OneTimerChallenge._oneTimer != null)    
            skillRef = OneTimerChallenge._oneTimer;       
        else if (PuckProtectionChallenge._puckProtection != null)        
            skillRef = PuckProtectionChallenge._puckProtection;      
        else if (PassingChallenge._passingChallenge != null)       
            skillRef = PassingChallenge._passingChallenge;       
        else if (ShootingAccuracyChallenge._shootingAccuracy != null)      
            skillRef = ShootingAccuracyChallenge._shootingAccuracy;       
        else if (FreeMode._freeMode != null)      
            skillRef = FreeMode._freeMode;    
        else       
            skillRef = null;
        
        return skillRef;
    }

    #endregion

} // end class SkillCompetition