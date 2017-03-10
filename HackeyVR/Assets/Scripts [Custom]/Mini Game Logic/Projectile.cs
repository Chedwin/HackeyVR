using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float destroyTime = 10.0f;
    public bool shot = false;

    void Start()
    {
        shot = false;
    }

    //public void StartDestroyPuck() {
    //    StartCoroutine(coroutine);
    //}

    //public void StopDestroyPuck() {
    //    StopCoroutine(coroutine);
    //    Debug.Log("Stop puck destroy");
    //}

    public IEnumerator DestroyPuck(float _time = 10.0f)
    {
        yield return new WaitForSeconds(_time);
        Destroy(gameObject);
    }
	
} // end class Projectile