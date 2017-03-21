using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This Script is used in case of VR malfunctions in the skill competitions
public class EmergencyExitHandler : MonoBehaviour {

    bool emergenyActivated = false;



	// Hold (Left Shift) + (Q) to return to MainLobby (Locker Room) scene
	void Update ()
    {
        if (Input.GetMouseButton(0)) {
            if (Input.GetMouseButton(1))
            {
                Debug.Log("Emergency escape activated");
                emergenyActivated = true;
                GameManager.Instance.SwitchScene("MainLobby", 2.0f);
            }
        }
    }

    private void OnGUI()
    {
        if (emergenyActivated) {
            GUI.color = Color.red;
            GUI.Box(new Rect(30, 30, 250, 30), "EMERGENCY EXIT ACTIVATED");

        }
    }

}
