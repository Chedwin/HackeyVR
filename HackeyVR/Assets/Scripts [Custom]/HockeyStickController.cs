using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;


public class HockeyStickController : MonoBehaviour {

    public GameObject leftStick;
    public GameObject rightStick;

    NVRHand nvrRightHand;


    void Awake() {
        nvrRightHand = this.GetComponent<NVRHand>();

        if (!nvrRightHand)
            Debug.Log("Hand not found");
    }

	// Use this for initialization
	void Start () {
        AttachStick(GameManager.Instance.stickHand);
    }

    void AttachStick(GameManager.STICKHANDEDNESS _stick)
    {
        if (_stick == GameManager.STICKHANDEDNESS.LEFT)
        {
            leftStick.SetActive(true);
            rightStick.SetActive(false);

            leftStick.transform.position = transform.position;

            nvrRightHand.Rigidbody = leftStick.GetComponent<Rigidbody>();
            nvrRightHand.CurrentlyInteracting = leftStick.GetComponent<NVRInteractableItem>();

        }
        else
        {
            leftStick.SetActive(false);
            rightStick.SetActive(true);

            rightStick.transform.position = transform.position;

            nvrRightHand.Rigidbody = rightStick.GetComponent<Rigidbody>();
            nvrRightHand.CurrentlyInteracting = rightStick.GetComponent<NVRInteractableItem>();
        }

    }
    

} // end class HockeyStickController