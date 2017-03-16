using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class WhiteboardHighScore : MonoBehaviour {

    public string[] gameNames = {
        "PassingChallenge",
        "ShootingAccuracy",
        "PuckProtection",
        "OneTimer"
    };

    const float MINUTE = 60.0f;
    public Text[] scoreTexts;

	// Use this for initialization
	void Start () {
        InitWhiteBoard();
	}

    void InitWhiteBoard()
    {  
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            string str = "HighScore";
            string highName = gameNames[i] + str;

            float highScore = PlayerPrefs.GetFloat(highName, 200.0f);
            DisplayHighScore(ref scoreTexts[i], highScore);
        }
    }

    void DisplayHighScore(ref Text _text, float _high)
    {
        if (_high < MINUTE)
        {
            decimal d = Math.Round((decimal)_high, 3);
            _text.text = d.ToString() + " sec";
        }
        else
        {
            int min = (int)Mathf.Floor(_high / 60.0f);
            int sec = (int)((_high % 60.0f));

            _text.text = min.ToString() + " min " + sec.ToString() + " sec";
        }
    }
	

} // end class WhiteboardHighScore
