using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefPurchase : MonoBehaviour
{

    //---------CodePERSECODE ---intial 1-- and CodePerSecondUpgraded---upgrade intial ---5
    //---------CODEReliabilityper----Initial---100%  and CODE Reliablility Update-----10---
    //--------Coins intitial ------initial----100% and Coins update also ----20
    //
    // Start is called before the first frame update

    private int add_initialdata = 1;

    private int m_intialcodevalue = 1;
    private int m_initialcodeReliability = 5;
    private int m_initlalCoinPurchase= 10;


    private int m_initialupgradeCodeValue = 5;
    private int m_initialUpgradeCodeReliability = 10;
    private int m_initialUpgradeCoinPurchase = 15;
    
    void Awake()
    {
        SetPlayerPreferenceInitialPurchace();
    }

   
    public void SetPlayerPreferenceInitialPurchace()
    {
        Debug.Log("initial data--" + GetaddedInitialdata());
        if (GetaddedInitialdata() != 1)//later you can change to not equal
        {
            Debug.Log("Player Pref Purchase");
            SetaddInitalValues(add_initialdata);
            SetCodePersecond(m_intialcodevalue);
            SetCodeReliability(m_initialcodeReliability);
            SetCoinsPercentage(m_initlalCoinPurchase);
            SetUpgradeCodePerSecondCoins(m_initialupgradeCodeValue);
            SetUpgradeCodeReliabilityCoins(m_initialUpgradeCodeReliability);
            SetUpgradeCoinsPercent(m_initialUpgradeCoinPurchase);
        }
    }
    private void SetaddInitalValues(int val)
    {
        PlayerPrefs.SetInt("addedInitaldata", val);
    }
    private int GetaddedInitialdata()
    {
        return PlayerPrefs.GetInt("addedInitaldata");
    }

    public void SetCodePersecond(int value)
    {

        PlayerPrefs.SetInt("CodePerSecond", value);

    }
    public void SetUpgradeCodePerSecondCoins(int value)
    {
        PlayerPrefs.SetInt("UpgradeCodePerSecond", value);
    }

    

    ///
    public void SetCodeReliability(int value)
    {
        PlayerPrefs.SetInt("CodeReliablity", value);
    }
    public void SetUpgradeCodeReliabilityCoins(int value)
    {
        PlayerPrefs.SetInt("UpgradeCodeReliablity", value);
    }
    //===========================

    public void SetCoinsPercentage(int value)
    {
        PlayerPrefs.SetInt("CoinsPercentage", value);
    }
    public void SetUpgradeCoinsPercent(int value)
    {
        Debug.Log("upgraded coins Percentage");
        PlayerPrefs.SetInt("UpgradeCoinsPercentage", value);
        Debug.Log("coins percent--->"+ GetCoinsPercentage());
        Debug.Log("upgraded coins percent--->"+ GetUpdatedCoinsPercentage());
        
    }

    ///getters
    ///
    public int GetCodePerSecond()
    {
        return PlayerPrefs.GetInt("CodePerSecond");
    }
    public int GetUpdateCodePersecond()
    {
        return PlayerPrefs.GetInt("UpgradeCodePerSecond");

    }
    //=======================================

    public int GetCodeReliability()
    {
        return PlayerPrefs.GetInt("CodeReliablity");
    }
    public int GetUpdateCodeReliablility()

    {
        return PlayerPrefs.GetInt("UpgradeCodeReliablity");
    }

    //==========================================

    public int GetCoinsPercentage()
    {
        return PlayerPrefs.GetInt("CoinsPercentage");
    }
    public int GetUpdatedCoinsPercentage()
    {
        return PlayerPrefs.GetInt("UpgradeCoinsPercentage");
    }



}
