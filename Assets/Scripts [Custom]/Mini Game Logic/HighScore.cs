using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public string highScoreName;
    public Text highScoreText;

    public float currentHighScore = 0;

	// Use this for initialization
	void Start ()
    {
        highScoreName = SceneManager.GetActiveScene().name + "HighScore";
        DisplayHighScore();
	}

    public void DisplayHighScore()
    {
        currentHighScore = GetHighScore();

        if (currentHighScore > 60.0f) {
            int min = (int)Mathf.Floor(currentHighScore / 60.0f);
            int sec = (int)((currentHighScore % 60.0f));

            string minStr = min.ToString();
            string secStr = sec.ToString();

            if (min < 10)
                minStr.PadLeft(2, '0');

            if (sec < 10)
                secStr.PadLeft(1, '0');

            highScoreText.text = minStr + ":" + secStr;
            return;
        }

        highScoreText.text = currentHighScore + " s";
    }

    public void SaveHighScore(float _score)
    {
        currentHighScore = _score;
        PlayerPrefs.SetFloat(highScoreName, _score);
        PlayerPrefs.Save();
    }

    public float GetHighScore()
    {
        currentHighScore = PlayerPrefs.GetFloat(highScoreName, 200.0f);
        return currentHighScore;
    }


} // end class HighScore
