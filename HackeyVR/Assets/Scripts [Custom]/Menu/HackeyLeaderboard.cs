using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

using UnityEngine.UI;

public class HackeyLeaderboard : MonoBehaviour {

    const string startTitle = "Scoreboard for: ";
    public string skillGameTitle;
    public Text title;

    public static HackeyLeaderboard _instance {
        get;
        private set;
    }

    public GameObject playerList;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start ()
    {
        title.text = startTitle + skillGameTitle;
        Load();
        scoreDB.SortScoreList();
        scoreDB.DebugHighScores();
        ScoreEntry en = scoreDB.GetRankEntry(9);
        Debug.Log(en.name);
    }

    // scoreboard
    public ScoreDatabase scoreDB;


    // save function
    public void Save()
    {
        // create a new xml file
        XmlSerializer serializer = new XmlSerializer(typeof(ScoreDatabase));
        string str = skillGameTitle.Replace(" ", String.Empty).ToLower();

        FileStream fs = new FileStream(Application.dataPath + "/XML/" + str + ".xml", FileMode.Create);
        serializer.Serialize(fs, scoreDB);

        fs.Close();
    }

    public void Load()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ScoreDatabase));

        string str = skillGameTitle.Replace(" ", String.Empty).ToLower();

        FileStream fs = new FileStream(Application.dataPath + "/XML/" + str + ".xml", FileMode.Open);

        if (fs == null) {
            Debug.Log("NULLLLLL");
            CreateNewHighScoreList();
            Load(); // recursion
        }

        scoreDB = serializer.Deserialize(fs) as ScoreDatabase;

        fs.Close();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyUp(KeyCode.Alpha0))
    //        Save();
    //}

    void PopulateLeaderBoard()
    {
        scoreDB.SortScoreList();
        
        for (int i = 0; i <= playerList.transform.childCount; i++)
        {
            GameObject sc = playerList.transform.GetChild(1).gameObject;
            
            Text name = sc.transform.FindChild("Name").gameObject.GetComponent<Text>();
            Text score = sc.transform.FindChild("Score").gameObject.GetComponent<Text>();

            ScoreEntry sena = scoreDB.GetRankEntry(i);


            if (sena == null)
            {
                name.text = "BBB";
                score.text = "0:99999";
                Debug.Log("sena is null at " + i);
                return;
            }

            name.text = scoreDB.GetRankEntry(i).name;
            score.text = scoreDB.GetRankEntry(i).score.ToString();
        }
    }

    public void CreateNewHighScoreList()
    {
        if (scoreDB.scoreList != null)
            return;

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWYZ";

        for (int i = 0; i < ScoreDatabase.maxCapacity; i++)
        {
            int f = UnityEngine.Random.Range(0, chars.Length);

            ScoreEntry n = new ScoreEntry();
            string newName = "";

            newName += chars[f];
            f = UnityEngine.Random.Range(0, chars.Length);
            newName += chars[f];
            f = UnityEngine.Random.Range(0, chars.Length);
            newName += chars[f];

            n.name = newName;
            n.score = UnityEngine.Random.Range(100.0f, 200.0f);

            scoreDB.InsertScore(ref n);
        }

        Save();
    }


    public void CheckHighScore(ref ScoreEntry _score)
    {
        scoreDB.InsertScore(_score.name, _score.score);

        int rank = scoreDB.GetEntryRank(ref _score);

        if (rank == -1)
            Debug.Log("you did not make the leaderboard");
        else
            Debug.Log("Your Rank is: " + rank);
    }


} // end class HackeyLeaderboard


/////////////////////////////////////////////////////////////////////////////////////////////////

[System.Serializable]
public class ScoreEntry : IComparable
{
    public string name;

    public float score;

    public int CompareTo(object obj)
    {
        if (obj == null)
            return 1;

        ScoreEntry sc = obj as ScoreEntry;
        if (sc != null)
            return this.score.CompareTo(sc.score);
        else
            throw new ArgumentException("This object is not a score entry");
    }

} // end struct ScoreEntry


///////////////////////////////////////////////////////

[System.Serializable]
public class ScoreDatabase
{
    public static int maxCapacity = 10;
    public List<ScoreEntry> scoreList = new List<ScoreEntry>();

    public bool InsertScore(string _name, float _score)
    {
        ScoreEntry temp = new ScoreEntry();
        temp.name = _name;
        temp.score = _score;

        scoreList.Add(temp);
       
        SortScoreList();

        if (scoreList.Count > maxCapacity) {
            Debug.LogError("Don't try to add more than 10 scores!");
            scoreList.RemoveAt(scoreList.Count);
            return false;
        }

        return true;
    }

    public bool InsertScore(ref ScoreEntry _scr)
    {
        scoreList.Add(_scr);

        SortScoreList();

        if (scoreList.Count > maxCapacity)
        {
            Debug.LogError("Don't try to add more than 10 scores!");
            scoreList.RemoveAt(scoreList.Count);
            return false;
        }

        return true;
    }

    public void SortScoreList()
    {
        if (scoreList.Count == 0)
            return;

        scoreList.Sort();
    }

    public ScoreEntry GetRankEntry(int _rank)
    {
        if (_rank > maxCapacity) {
            Debug.LogError("Rank does not exist");
            return null;
        }

        ScoreEntry sc = scoreList[_rank];
        return scoreList[_rank];
    }

    public int GetEntryRank(ref ScoreEntry _s)
    {
        int rk = scoreList.IndexOf(_s);

        if (rk != -1)
            return rk;

        return -1;
    }

    public bool RemoveEntry(uint _rank)
    {
        if (_rank > maxCapacity) { 
            Debug.LogError("Rank does not exist");
            //throw new IndexOutOfRangeException();
            return false;
        }

        scoreList.RemoveAt((int)_rank);
        return true;
    }

    public int GetSize()
    {
        return scoreList.Count();
    }

    public void DebugHighScores()
    {
        foreach (ScoreEntry s in scoreList)
        {
            Debug.Log("Name: " + s.name + "   Score: " + s.score);
        }
    }



} // end class ScoreDataBase