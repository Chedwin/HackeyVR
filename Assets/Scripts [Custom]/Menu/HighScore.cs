using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    string highScoreName;
    public Text highScoreText;

	// Use this for initialization
	void Start ()
    {
        highScoreName = SceneManager.GetActiveScene().name + "HighScore";
        DisplayHighScore();
	}

    public void DisplayHighScore()
    {
        highScoreText.text = GetHighScore().ToString() + " s";
    }

    public void SaveHighScore(float _score)
    {
        PlayerPrefs.SetFloat(highScoreName, _score);
        PlayerPrefs.Save();
    }

    public float GetHighScore()
    {
        return PlayerPrefs.GetFloat(highScoreName , 100.0f);
    }


} // end class HighScore
