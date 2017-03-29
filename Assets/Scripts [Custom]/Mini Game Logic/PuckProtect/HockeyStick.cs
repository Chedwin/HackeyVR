using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HockeyStick : MonoBehaviour
{
    GameObject blade;
    

	// Use this for initialization
	void Start ()
    {
        blade = transform.FindChild("Blade").gameObject;
	}

    void OnCollisionEnter(Collision c)
    {
        blade.GetComponent<BladePossesion>().StickCollision(c);
    }

} // end class HockeyStick
