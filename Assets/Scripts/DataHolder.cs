using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : Singleton<DataHolder>
{
    public const string HighScorePrefsString = "HighScore";
    public const string LastScorePrefsString = "LastScore";
    //Awake
    int _highScore = 0;

    int _lastScore = 0;

    public int HighScore => _highScore;
    public int LastScore => _lastScore;
    protected override void Awake()
    {
        base.Awake();

        if (Instance != this) return;

        if(PlayerPrefs.HasKey(HighScorePrefsString))
        {
            _highScore = PlayerPrefs.GetInt(HighScorePrefsString);
        }
        else
        {
            PlayerPrefs.SetInt(HighScorePrefsString, 0);
            PlayerPrefs.Save();
        }

        if(PlayerPrefs.HasKey(LastScorePrefsString))
        {
            _lastScore = PlayerPrefs.GetInt(LastScorePrefsString);
        }
        else
        {
            PlayerPrefs.SetInt(LastScorePrefsString, 0);
            PlayerPrefs.Save();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SetScore(int newScore)
    {
        if(newScore > HighScore)
        {
            _highScore = newScore;
            PlayerPrefs.SetInt(HighScorePrefsString, HighScore);
            return true;
        }
        _lastScore = newScore;
        PlayerPrefs.SetInt(LastScorePrefsString, _lastScore);
        PlayerPrefs.Save();
        return false;
    }
}
