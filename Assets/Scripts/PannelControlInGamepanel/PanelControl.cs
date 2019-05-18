using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour
{
    public GameObject m_pausepanel;
    public GameObject LevelPannel;
    public GameObject CoinsPannel;
    public GameObject GameOverPannel;
    public GameObject ExtralifePannel;
    public GameObject m_bigenemycoins;
    private GameManagerController m_gameStatus;

    
    // Start is called before the first frame update
    void Start()
    {
        startingPannels();
        m_gameStatus = FindObjectOfType<GameManagerController>();
    }


    private void startingPannels()
    {
        LevelPannel.SetActive(true);
        CoinsPannel.SetActive(true);
        GameOverPannel.SetActive(false);
        ExtralifePannel.SetActive(false);
    }
    public void setExtraLifePanel()
    {
        ExtralifePannel.SetActive(true);

    }
    public void setActiveGameOverPannel()
    {
        DeactivateExtralifePanel();
        m_gameStatus.setGameOverinfo(true);
        GameOverPannel.SetActive(true);
        LevelPannel.SetActive(false);
    }
    public void DeactivateExtralifePanel()
    {
        ExtralifePannel.SetActive(false);
    }
    public void UseExtraLifewithVideoad()
    {
        m_gameStatus.SetExtralifeoption(false);
        m_gameStatus.setafterrebirth(true);
        ExtralifePannel.SetActive(false);

    }
    public void CheckExtralifeAmount()
    {
        UseExtraLifewithVideoad();
    }
    public void  setbigEnemYcoinspanel()
    {
        m_bigenemycoins.SetActive(true);
        LevelPannel.SetActive(false);
    }
    public void SetbigEnemyDeacitve()
    {
        m_gameStatus.ifnotBigPlayer();
        m_bigenemycoins.SetActive(false);
    }

   public void PausePanelActive()
    {
        m_pausepanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void PausePanelDeactive()
    {
        Time.timeScale = 1;
        m_pausepanel.SetActive(!m_pausepanel.activeSelf);
    }
}


