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

        Projectile proj = other.GetComponent<Projectile>();

        if (proj.shot == true)
            return;

        proj.shot = true;

        SetHit();
    }


    void SetHit()
    {
        if (netSide == NetSide.Front)
            free.HomeScore();
        else
            free.VisitorScore();
    }

} // end class GoalCounter