using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdManager : MonoBehaviour {

    public static CrowdManager Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        // First we check if there are any other instances conflicting
        if (Instance != null && Instance != this)
        {
            // If that is the case, we destroy other instances            
            Destroy(gameObject);
        }

        // Here we save our singleton instance
        Instance = this;
    }

    public List<HockeyFanAI> fans = new List<HockeyFanAI>();

    // Use this for initialization
    void Start ()
    {
        HockeyFanAI[] f = GameObject.FindObjectsOfType<HockeyFanAI>();

        foreach (HockeyFanAI fff in f) {
            fans.Add(fff);
        }

        Debug.Log(fans.Count + " fans found!");
	}
	


    public void AllCheer()
    {
        foreach (HockeyFanAI fan in fans)
        {
            int chance = Random.Range(0, 10);
            if (fan.loyalty == HockeyFanAI.LOYALTY.BOS && (chance <= 9))
            {
                fan.Boo();
                break;
            }
            fan.Cheer(); // not all Boston fans are bad, okay?
        }
    }

    public void AllBoo()
    {
        foreach (HockeyFanAI fan in fans)
        {
            int chance = Random.Range(0, 10);
            if (chance <= 8)
                fan.Boo();
        }
    }

} // end class CrowdManager
