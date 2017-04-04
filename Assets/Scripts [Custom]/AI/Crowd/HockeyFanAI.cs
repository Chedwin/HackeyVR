using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HockeyFanAI : MonoBehaviour
{
    Animator anim;
    float timer = 0.0f;

    public enum LOYALTY {
        TOR = 0,
        MTL = 1,
        BOS = 2,
        EDM = 3,
        OTT = 4,
        CGY = 5
    }

    public LOYALTY loyalty;

    [Range(10.0f, 30.0f)]
    public float randomCheerInterval;

    // Use this for initialization
    protected virtual void Start ()
    {
        anim = GetComponent<Animator>();
        randomCheerInterval = Random.Range(10.0f, 30.0f);
    }

    // update
    protected virtual void Update()
    {
        timer += Time.deltaTime;
        RandomCheer(randomCheerInterval);
    }

    // Update is called once per frame
    public virtual void Cheer(string _cheer = "cheer")
    {
        anim.SetTrigger(_cheer);
        //Debug.Log(gameObject.name + " cheered!");
	}

    public virtual void Boo(string _boo = "boo")
    {
        anim.SetTrigger(_boo);
        //Debug.Log(gameObject.name + " booed...");
    }

    protected void RandomCheer(float _maxTime = 30.0f)
    {
        if (timer >= _maxTime) {

            int rand = Random.Range(0, 10);

            if (rand < 5)
            {
                if (loyalty == LOYALTY.BOS)
                    Boo();
                else
                    Cheer();
            }
            timer = 0.0f;
            randomCheerInterval = Random.Range(10.0f, 30.0f);
        }
    }

} // end HockeyFanAI
