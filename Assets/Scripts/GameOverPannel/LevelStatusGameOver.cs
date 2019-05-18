using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelStatusGameOver : MonoBehaviour
{
    public TextMeshProUGUI m_yourFixes;
    public TextMeshProUGUI max_fixes;
    public TextMeshProUGUI percentageLevel;
    public TextMeshProUGUI Currentlevel;
    public TextMeshProUGUI NextLevel;

    public Image FillBar;

    private PlayerCurrentNextPref m_level;
    private PlayerLevelControl m_currentScore;
    private LeveLCompletion m_levelCompletion;

    

    private int CaluculatePercentage=100;
    // Start is called before the first frame update
    void Start()
    {
        m_level = FindObjectOfType<PlayerCurrentNextPref>();
        m_currentScore = FindObjectOfType<PlayerLevelControl>();
        m_levelCompletion = FindObjectOfType<LeveLCompletion>();

       // GetGameOveStatus();
    }

    private void FixedUpdate()
    {
        GetGameOveStatus();
    }
    private void GetGameOveStatus()
    {
        if(FindObjectOfType<GameManagerController>().getGameOver())
        {
            getLevelStatus();
        }

    }




 
    private void getLevelStatus()
    {
        Currentlevel.SetText(m_level.GetPlayerCurrentLevel().ToString());
        NextLevel.SetText(m_level.GetPlayerNextLevel().ToString());
        m_yourFixes.SetText(m_currentScore.GetCurrentScore().ToString());
        max_fixes.SetText("MAX FIXES :" + m_level.GetBestScore().ToString());
        //percentageLevel.SetText(((int)Mathf.Floor(GetPercentageofLevelComplete())).ToString() + "% Fixed");
        percentageLevel.SetText(GetPercentageofLevelComplete().ToString() + "% Fixed");
        FillBar.fillAmount = m_levelCompletion.getLevelfillAmount();
    }

    private float GetPercentageofLevelComplete()
    {
       return m_levelCompletion.getLevelfillAmount()*CaluculatePercentage;
    }

    public void MoveToMainMenu()
    {
        SceneManager.LoadScene(0);
        //Application.LoadLevel(0);
    }
}
