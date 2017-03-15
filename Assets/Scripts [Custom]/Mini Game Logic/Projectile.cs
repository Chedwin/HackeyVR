using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float destroyTime = 10.0f;
    public bool shot = false;
    Rigidbody rb;

    void Start()
    {
        shot = false;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.Instance.isPaused)
            rb.constraints = RigidbodyConstraints.FreezeAll;
        else
            rb.constraints = RigidbodyConstraints.None;
    }

    public IEnumerator DestroyPuck(float _time = 10.0f)
    {
        yield return new WaitForSeconds(_time);
        Destroy(gameObject);
    }

} // end class Projectile