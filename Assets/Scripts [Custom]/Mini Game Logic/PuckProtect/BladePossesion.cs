//*******************************//
//
// Class Name:		BladePossesion
// Description:		
//
// Author(s):	    Edwin Chen, Andrew Palangio
// Special Thanks:  
//
// Created:			Jan 27, 2017
// Last updated:	Feb 28, 2017
//
//*******************************//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladePossesion : MonoBehaviour {

    GameObject playerPuck;
    public GameObject sphereObj;

    Renderer sphRenderer;
    SphereCollider sph;

    public Material normalSphere;
    public Material warningSphere;
    public Material badSphere;

    float possTimer = 5.0f;

    public float puckCountdownTime = 5.0f;
    public float sphereRadius = 1.5f;

    PuckProtectionChallenge _puckProtRef;

    AudioSource audioS;
    AudioClip eff;

    void Start()
    {
        sph = GetComponent<SphereCollider>();
        //sphRenderer = sphereObj.GetComponent<Renderer>();
        _puckProtRef = PuckProtectionChallenge._puckProtection;

        playerPuck = PuckProtectionChallenge._puckProtection.playerPuck;
        audioS = GetComponent<AudioSource>();

        eff = AudioManager.Instance.GetSFXClip("error");
        audioS.clip = eff;
        RestartBlade();
    }

    public void RestartBlade()
    {
        possTimer = puckCountdownTime;
        sphRenderer = sphereObj.GetComponent<Renderer>();
        sphRenderer.material = normalSphere;
    }


    private void Update()
    {
        if (GameManager.Instance.isPaused == false && _puckProtRef.gameStarted && _puckProtRef.gameOver == false) {
            if (_puckProtRef.inPossession == false) {
                possTimer -= Time.deltaTime;

                if (possTimer <= 0.0f)
                    possTimer = 0.0f;
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerPuck && !GameManager.Instance.isPaused) {

            if (_puckProtRef.gameStarted == false)
                _puckProtRef.gameStarted = true;

            _puckProtRef.inPossession = true;
            possTimer = puckCountdownTime;
            StopAllCoroutines();
            AudioManager.Instance.StopClip();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject != playerPuck || GameManager.Instance.isPaused)
            return;

        float dis = (playerPuck.transform.position - transform.position).magnitude;

        float r = sph.radius * 1.85f;
        if (dis >= r)
        {
            sphRenderer.material = warningSphere;
        }
        else
        {
            sphRenderer.material = normalSphere;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == playerPuck && _puckProtRef.inPossession && !GameManager.Instance.isPaused)
        {
            _puckProtRef.inPossession = false;
            sphRenderer.material = badSphere;
            StartCoroutine(LostPuckPossessionCountdown(puckCountdownTime));
            AudioManager.Instance.PlayClip("countdownTimer");
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position, sphereRadius);
    //}

    IEnumerator LostPuckPossessionCountdown(float _time)
    {
        yield return new WaitForSeconds(_time);

        if (_puckProtRef.inPossession == false)
        {
            _puckProtRef.CheckFinish();
        }
    }

    public void StickCollision(Collision c)
    {
        if (c.gameObject.name.Contains("ProjectilePuck")) {
            
            _puckProtRef.puckstickHit++;

            audioS.Play();

            if (_puckProtRef.puckstickHit == _puckProtRef.maxPuckHit) {
                StopAllCoroutines();
                _puckProtRef.CheckFinish();
            }
        }
    }

    private void OnGUI()
    {
        int width = 160;
        int height = 40;
        string pucksRemain = (_puckProtRef.maxPuckHit - _puckProtRef.puckstickHit).ToString();
        GUI.color = Color.blue;
        GUI.Box(new Rect(Camera.main.pixelWidth - width, Camera.main.pixelHeight - height, 140, height - 10), "Puck Hit Remaining: " + pucksRemain);

        string time = Mathf.Floor(possTimer + 0.9f).ToString();
        if (possTimer == 0.0f)
            time = "0";

        GUI.color = Color.blue;
        GUI.Box(new Rect(20, Camera.main.pixelHeight - height, 200, height - 10), "Possesion Time Remaining: " + time + " s");

        if (_puckProtRef.gameOver)
        {
            GUI.color = Color.red;
            GUI.Box(new Rect(Camera.main.pixelWidth/2 * 0.8f, 30, 140, height - 10), "GAME OVER");
        }

    }


} // end class BladePossesion
