//*******************************//
//
// Class Name:		CanvasCameraMenu
// Description:		
//
// Author(s):	    Edwin Chen, Andrew Palangio
// Special Thanks:  
//
// Created:			Mar 19, 2017
// Last updated:	Mar 29, 2017
//
//*******************************//

using UnityEngine;

public class CanvasCameraMenu : MonoBehaviour {

    Canvas canvas;

	// Use this for initialization
	void Awake ()
    {
        canvas = GetComponent<Canvas>();       
	}

    Camera FindPlayerCamera()
    {
        return GameObject.Find("Controller UI Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (canvas.worldCamera == null)
            canvas.worldCamera = FindPlayerCamera();
    }

    public void DisableTutorialPanel()
    {
        gameObject.SetActive(false);
    }

} // end class CanvasCameraMenu
