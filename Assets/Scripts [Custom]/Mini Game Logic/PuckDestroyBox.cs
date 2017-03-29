using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckDestroyBox : MonoBehaviour
{

    void OnTriggerEnter(Collider col) {

        if (col.gameObject.tag == "Puck" || col.gameObject.tag == "Ball") {
            Destroy(col.gameObject);
            Debug.Log("Destory!!!!!");
        }
    }

}
