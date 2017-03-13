using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckBucket : MonoBehaviour {

    public GameObject puck;
    public Transform spawnPoint;

    [Range(0.5f, 3.0f)]
    public float shootSpeed = 0.5f;

    public bool canSpawnPuck = true;
    const float puckSpawnDelay = 3.0f;

    // Use this for initialization
    void Start()
    {
        canSpawnPuck = true;
    }


    //private void Update()
    //{
    //    timer += Time.deltaTime;
    //    if ((timer > 5.0f) && (canSpawnPuck == false))
    //    {
    //        canSpawnPuck = true;
    //        timer = 0.0f;
    //    }
    //}

    private void OnCollisionEnter(Collision col)
    {
        if (canSpawnPuck == false)
            return;

        if (col.gameObject.tag == "HockeyStick")
        {
            StartCoroutine(WaitPuckDelay(puckSpawnDelay));
        }
    }

    IEnumerator WaitPuckDelay(float _time = 1.0f)
    {
        SkillCompetition sk = SkillCompetition.GetSkillRef();
        sk.ShootPuck(spawnPoint.transform.position, spawnPoint.transform.right, 0.0f, shootSpeed);
        canSpawnPuck = false;
        yield return new WaitForSeconds(_time);
        canSpawnPuck = true;
    }

} // end class PuckBucket
