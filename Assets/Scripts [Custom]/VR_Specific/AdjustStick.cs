using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SteamVR_TrackedObject))]
public class AdjustStick : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;
    public SteamVR_Controller.Device device;


    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    private SteamVR_Controller.Device Controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }



    // 1
    public void FixedUpdate()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // 2
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "HockeyStick")
            return;

        if (Controller.GetHairTriggerUp()) {
            GameObject hockeyStick = other.gameObject;
            Transform snapPoint = hockeyStick.transform.FindChild("SnapPoint");

            if (!snapPoint) {
                Debug.Log("NOOO");
            }


            Vector3 p = snapPoint.InverseTransformPoint(transform.position - snapPoint.position);
            float dis = p.magnitude;

            float newDis = (p.z > 0.0f) ? dis * -1.0f : dis;

            Debug.Log(dis);
            

            Vector3 newSnapPos = new Vector3(0, 0, newDis);
            snapPoint.Translate(newSnapPos, Space.Self);
        }
    }

    // 3
    public void OnTriggerExit(Collider other)
    {
        
    }


} // end class AdjustStick
