﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyExitHandler : MonoBehaviour {

    bool emergenyActivated = false;
    // This Script is used in case of VR malfunctions in the skill competitions

	// Hold (Left Shift) + (Q) to return to MainLobby (Locker Room) scene
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftControl)) {
            if (Input.GetKeyUp(KeyCode.Q)) {
                Debug.Log("Emergency escape activated");
                emergenyActivated = true;
                GameManager.Instance.SwitchScene("MainLobby", 2.0f);
            }
        }
    }

    private void OnGUI()
    {
        if (emergenyActivated) {
            
            GUI.Box(new Rect(30, 30, 250, 40), "EMERGENCY EXIT ACTIVATED");

        }
    }

}
