using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrentNextPref : MonoBehaviour
{

    private int m_currentLevel=0;
    private int m_initialvalues=1;
    private int Completed;
    // Start is called before the first frame update
    void Start()
    {
        Completed = 0;
        addLeveldata();
        SetPlayerLevelCompleted(Completed);
    }

    public void addLeveldata()
    {
        if (Getintialadded() != 1)
        {
            SetPlayerCurrentLevel(m_currentLevel);
            IsLevelinitialAdded(m_initialvalues);
        }
    }
 
    public void IsLevelinitialAdded(int value)
    {
        PlayerPrefs.SetInt("valueis", value);
    }
    public int Getintialadded()
    {
        return PlayerPrefs.GetInt("valueis");
    }



    public void SetPlayerCurrentLevel(int Level)
    {
        PlayerPrefs.SetInt("CurrentLevel", Level);
        SetPlayernextLevel(Level + 1);
    }
    public int GetPlayerCurrentLevel()
    {
          return PlayerPrefs.GetInt("CurrentLevel");
    }


    public void SetPlayernextLevel(int level)
    {
        PlayerPrefs.SetInt("NextLevel", level);

    }
    public int GetPlayerNextLevel()
    {
        return PlayerPrefs.GetInt("NextLevel");
    }

    public void  SetBestScore(int value)
    {
        PlayerPrefs.SetInt("BestScore", value);
    }
    public int GetBestScore()
    {
        return PlayerPrefs.GetInt("BestScore");
    }

    public void SetPlayerLevelCompleted(int completed)
    {
        PlayerPrefs.SetInt("LevelCompleted", completed);

    }
    public int getPlayerLevelCompleted()
    {
         return   PlayerPrefs.GetInt("LevelCompleted");
    }

   
}


