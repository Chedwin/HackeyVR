using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCameraMenu : MonoBehaviour {

    Canvas canvas;

	// Use this for initialization
	void Awake () {
        canvas = GetComponent<Canvas>();       
	}

    private void Start()
    {
        //canvas.worldCamera = FindPlayerCamera();
    }

    private void OnEnable()
    {
        canvas.worldCamera = FindPlayerCamera();
    }

    Camera FindPlayerCamera()
    {
        return GameObject.Find("Controller UI Camera").GetComponent<Camera>();
    }

    //private void Update()
    //{
    //    canvas.worldCamera = GameObject.Find("Controller UI Camera").GetComponent<Camera>();
    //}

    public void DisableTutorialPanel()
    {
        gameObject.SetActive(false);
    }
}
