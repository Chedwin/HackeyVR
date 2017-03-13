using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaucerNet : MonoBehaviour
{
    public GameObject check;
    public GameObject cross;
    PassingChallenge pass;

    int layer;
    public bool isHit = false;

    void Start()
    {
        layer = LayerMask.NameToLayer("HockeyPhysics");
        isHit = false;
        SetIcon(isHit);
        pass = PassingChallenge._passingChallenge;
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == layer) && (isHit == false)) 
        {
            isHit = true;
            SetIcon(isHit);

            other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.angularVelocity = Vector3.zero;


            Projectile proj = other.gameObject.GetComponent<Projectile>();
            StopCoroutine(proj.DestroyPuck());

            pass.playerScore++;
            pass.SetHomeScoreText(pass.playerScore);
            pass.CheckFinish();            
        }
    }

    public void SetIcon(bool _hit) {
        cross.SetActive(!_hit);
        check.SetActive(_hit);
    }

} // end class SaucerNet
