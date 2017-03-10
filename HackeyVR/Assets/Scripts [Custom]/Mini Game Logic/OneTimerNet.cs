using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimerNet : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Puck")
            return;

        Projectile proj = other.gameObject.GetComponent<Projectile>();

        if (proj.shot)
            return;

        proj.shot = true;
        OneTimerChallenge inst = OneTimerChallenge._oneTimer;

        inst.playerScore++;
        inst.SetHomeScoreText(inst.playerScore);
        inst.CheckFinish();
    }


} // end class OneTimerNet
