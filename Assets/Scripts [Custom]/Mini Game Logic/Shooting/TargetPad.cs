using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetPad : MonoBehaviour {

    Rigidbody rb;
    int hockeyLayer;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        hockeyLayer = LayerMask.NameToLayer("HockeyPhysics");
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Puck" || col.gameObject.layer == hockeyLayer)
        {
            Debug.Log("collision w/ " + col.gameObject.name);
            rb.useGravity = true;

            // Destory the colliding ball/puck
            Destroy(col.gameObject, 0.5f);
            
            Destroy(gameObject, 1.0f);

            ShootingAccuracyChallenge shtAcc = ShootingAccuracyChallenge._shootingAccuracy;
            shtAcc.playerScore++;
            shtAcc.SetHomeScoreText(shtAcc.playerScore);
            shtAcc.CheckFinish();
        }
    }


} // end class TargetPad