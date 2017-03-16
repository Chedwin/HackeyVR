using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCameraMenu : MonoBehaviour {

    Canvas canvas;

	// Use this for initialization
	void Awake () {
        canvas = GetComponent<Canvas>();       
	}


    private void Update()
    {
        canvas.worldCamera = GameObject.Find("Controller UI Camera").GetComponent<Camera>();
    }
}
