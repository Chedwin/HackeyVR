using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class HighScore : MonoBehaviour {

    const float defaultHighScore = 200.0f;
    public string highScoreName;
    public Text highScoreText;

    public float currentHighScore = 0;

	// Use this for initialization
	void Start ()
    {
        highScoreName = SceneManager.GetActiveScene().name + "HighScore";

        DisplayHighScore();
	}


    // Hold Left CTRL + Left ALT + N to reset high score
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftControl)) {
            if (Input.GetKeyUp(KeyCode.N)) {
                float rand = UnityEngine.Random.Range(defaultHighScore / 2.0f, defaultHighScore * 1.25f);
                SaveHighScore(rand);
                DisplayHighScore();
            }
        }

    }


    public void DisplayHighScore()
    {
        currentHighScore = GetHighScore();

        if (currentHighScore > 60.0f) {
            int min = (int)Mathf.Floor(currentHighScore / 60.0f);
            int sec = (int)((currentHighScore % 60.0f));

            highScoreText.text = min.ToString() + " min " + sec.ToString() + " sec";
            return;
        }

        decimal d = Math.Round((decimal)currentHighScore, 3);
        highScoreText.text = d.ToString() + " sec";
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
