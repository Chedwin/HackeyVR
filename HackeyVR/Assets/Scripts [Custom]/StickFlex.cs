using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickFlex : MonoBehaviour {

    public GameObject flexer;
    Bend bender;
    Rigidbody rigid;

    const float flexMax = 1.0f;

	// Use this for initialization
	void Start () {
        bender = flexer.GetComponent<Bend>();
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


} // end class StickFlex
