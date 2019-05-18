using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerLevelControl : MonoBehaviour
{

    public TextMeshProUGUI CurrentLevel;
    public TextMeshProUGUI NextLevel;

    public TextMeshProUGUI UpdateScoreText;

    private PlayerCurrentNextPref m_level;

    private int[] updateScore = {1,2,3,4,5};
    private int Score ;

    void Start()
    {
        Score = 0;
        m_level = FindObjectOfType<PlayerCurrentNextPref>();
        setTextmeshProdata();
    }

    void Update()
    {
        ScoreinText();
    }
    private void setTextmeshProdata()
    {
        CurrentLevel.SetText(m_level.GetPlayerCurrentLevel().ToString());
        NextLevel.SetText(m_level.GetPlayerNextLevel().ToString());
    }
    
    private void ScoreinText()
    {
        UpdateScoreText.SetText(Score.ToString());
    }
    public void updateScoreui()
    {
        Score = Score + updateScore[Random.Range(0, updateScore.Length)];
        Debug.Log("score is  --" + Score);
        if(Score>m_level.GetBestScore())
        {
            m_level.SetBestScore(Score);
        }

    }
    public int GetCurrentScore()
    {
        return Score;
    }
}
