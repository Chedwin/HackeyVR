using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HockeyStick : MonoBehaviour {

    GameObject blade;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        blade = transform.FindChild("Blade").gameObject;
	}

    void OnCollisionEnter(Collision c)
    {
        blade.GetComponent<BladePossesion>().StickCollision(c);
    }

}
