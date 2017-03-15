using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPhysics : MonoBehaviour {

    Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    //// Update is called once per frame
    //void Update () {

    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Puck")
        {
            Rigidbody r = collision.gameObject.GetComponent<Rigidbody>();

        }
    }

    private void OnCollisionStay(Collision collision)
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Puck")
        {

        }
    }

} // end class StickPhysics
