using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCounter : MonoBehaviour {

    public static int goalCount;
    int hockeyPhysicsLayer;

    private void Start()
    {
        hockeyPhysicsLayer = LayerMask.NameToLayer("HockeyPhysics");
        goalCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == hockeyPhysicsLayer)
        {
            StartCoroutine("GoalHorn");
        }
    }

    IEnumerable GoalHorn()
    {
        goalCount++;
        yield return new WaitForSeconds(3.0f);
    }

    

} // end class GoalCounter