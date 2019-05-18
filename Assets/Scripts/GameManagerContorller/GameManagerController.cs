
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    private bool isGameOver;
    private bool islevelCommpleted;
    private PanelControl controlpanel;
    private PlayerCurrentNextPref m_player;
    private bool callOnlyOnce;
    private bool CallOnlyonceLevelCompleted;
    private bool isExtraLife;

    private bool isrebirth;
    // Start is called before the first frame update
    void Start()
    {
        controlpanel = FindObjectOfType<PanelControl>();
        m_player = FindObjectOfType<PlayerCurrentNextPref>();
        m_player.SetPlayerLevelCompleted(0);
        setGameOverinfo(false);
        setlevelComplete(false);
    }

    // Update is called once per frame
    void Update()
    {
        isCheckGameOver();
        checkLevelCompleted();
    }
    public void setGameOverinfo(bool value)
    {
        isGameOver = value;
    }
    public bool getGameOver()
    {
        return isGameOver;
    }

    public  void setlevelComplete(bool value)
    {
        islevelCommpleted = value;
    }
    public bool getLevecompletestatus()
    {
        return islevelCommpleted;
    }


    private void  isCheckGameOver()
    {
        if (getGameOver())
        {
            if (!callOnlyOnce)
            {
               // controlpanel.setExtraLifePanel();
                callOnlyOnce = !callOnlyOnce;
            }
        }
    }


   private void checkLevelCompleted()
    {

        if (getLevecompletestatus())
        {
            if (!CallOnlyonceLevelCompleted)
            {

                if(m_player.GetPlayerCurrentLevel()>0&&m_player.GetPlayerCurrentLevel()%5==0)
                {
                    controlpanel.setbigEnemYcoinspanel();
                    //call big enemy in player completed pannel in 
                    //after you have to call if not bigplayer
                }
                else
                {
                    ifnotBigPlayer();
                }
              
            }
        }
    }

    
    public void ifnotBigPlayer()
    {

        m_player.SetPlayerLevelCompleted(1);
        SetPPlayerIncrement();
        CallOnlyonceLevelCompleted = !CallOnlyonceLevelCompleted;
        SceneManager.LoadScene(0);
    }


    private void SetPPlayerIncrement()
    {
        m_player.SetPlayerCurrentLevel(m_player.GetPlayerCurrentLevel() + 1);
    }


    public void SetExtralifeoption(bool result)
    {
        isExtraLife = result;
    }

    public bool getExtraliferesult()
    {
        return isExtraLife;
    }
    public void setafterrebirth(bool birth)

    {
        isrebirth = birth;
    }
    public bool GetRebirth()
    {
        return isrebirth;
    }


}
