using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreDisplay : MonoBehaviour {

    HackeyLeaderboard leaderBoard;
    public GameObject[] blocks;

	// Use this for initialization
	void Start ()
    {
        leaderBoard = HackeyLeaderboard._instance;
	}
	
	// Update is called once per frame
	void Display ()
    {
        foreach (GameObject b in blocks)
        {
            Text name = b.transform.FindChild("Name").gameObject.GetComponent<Text>();
            //f.text = 

            Text score = b.transform.FindChild("Score").gameObject.GetComponent<Text>();


            Text date = b.transform.FindChild("Date").gameObject.GetComponent<Text>();

        }
	}

} // end class HighScoreDisplay
