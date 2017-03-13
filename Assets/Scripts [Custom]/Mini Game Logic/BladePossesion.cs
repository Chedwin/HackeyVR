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

    public float puckCountdownTime = 5.0f;
    public float sphereRadius = 1.5f;

    PuckProtectionChallenge _puckProtRef;

    void Start()
    {
        sph = GetComponent<SphereCollider>();
        sphRenderer = sphereObj.GetComponent<Renderer>();
        sphRenderer.material = normalSphere;
        _puckProtRef = PuckProtectionChallenge._puckProtection;

        playerPuck = PuckProtectionChallenge._puckProtection.playerPuck;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == playerPuck && !GameManager.Instance.isPaused) {

            if (_puckProtRef.gameStarted == false)
                _puckProtRef.gameStarted = true;

            _puckProtRef.inPossession = true;
            StopCoroutine(LostPuckPossessionCountdown(puckCountdownTime));
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
            
            PuckProtectionChallenge puckRef = PuckProtectionChallenge._puckProtection;

            puckRef.puckstickHit++;

            if (puckRef.puckstickHit == puckRef.maxPuckHit)
                _puckProtRef.CheckFinish();
        }
    }


} // end class BladePossesion
