using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPannelContol : MonoBehaviour
{
    public GameObject LevelCompletePanel;
    public GameObject GameUIPanel;
    public GameObject SettingsPanel;
    public GameObject PlayerUpgradePannel;
    public GameObject CreditsPannel;


    private PlayerCurrentNextPref m_levelCheck;



   




    void Start()
    {
        m_levelCheck = FindObjectOfType<PlayerCurrentNextPref>();
        CheckLevelCompleted();
    }

  
    private void CheckLevelCompleted()
    {
        if (m_levelCheck.getPlayerLevelCompleted() == 1)
        {
            LevelCompletePanel.SetActive(true);
            GameUIPanel.SetActive(false);
            SettingsPanel.SetActive(false);
            CreditsPannel.SetActive(false);
        }
        else
        {
            PlayerUpgradePannel.SetActive(false);
            LevelCompletePanel.SetActive(false);
            CreditsPannel.SetActive(false);
            GameUIPanel.SetActive(true);
            SettingsPanel.SetActive(true);
        }
    }
    public void  PlayerUpgradePannelActive()
    {
        PlayerUpgradePannel.SetActive(true);
    }
    public void ClosPlayerUpgradepannel()
    {
        PlayerUpgradePannel.SetActive(!PlayerUpgradePannel.activeSelf);
    }    

    public void ActiveCreditsPannel()
    {
        CreditsPannel.SetActive(!CreditsPannel.activeSelf);
    }
    public void DeacitveCreditsPanel()
    {
        CreditsPannel.SetActive(!CreditsPannel.activeSelf);
    }

}
