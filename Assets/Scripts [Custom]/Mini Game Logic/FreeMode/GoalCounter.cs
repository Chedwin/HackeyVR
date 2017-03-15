using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCounter : MonoBehaviour {

    public enum NetSide {
        Front = 0,
        Back = 1
    }
    public NetSide netSide;

    int hockeyPhysicsLayer;
    FreeMode free;

    private void Start()
    {
        hockeyPhysicsLayer = LayerMask.NameToLayer("HockeyPhysics");
        free = FreeMode._freeMode;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != hockeyPhysicsLayer)
            return;

        if (netSide == NetSide.Front) {
            free.playerScore++;
            free.SetHomeScoreText(free.playerScore);
        } else {
            free.backNetScore++;
            free.awayScore.text = free.backNetScore.ToString();
        }
    }

} // end class GoalCounter