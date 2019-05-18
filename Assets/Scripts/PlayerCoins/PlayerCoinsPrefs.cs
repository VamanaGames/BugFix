using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinsPrefs : MonoBehaviour
{
    private float m_availCOinsinit=0;
    private int modifiedcoinsinitial = 0;
    private int m_availDimondsinit=0;
    private int m_avail_Heartinit=0;
    private int m_addedData;
    private float coinValue=0.4f;
    // Start is called before the first frame update
    void Start()
    {
     
        if (GetPlayerinfoin()!=1)//later you have to change coins !=1
        {
            addplayerCoinsinfo();
        }

    }

 
  

    private void addplayerCoinsinfo()
    {
        SetTempAvailCoins(m_availCOinsinit);
        SetAvailDiamonds(m_availDimondsinit);
        setAvailHearts(m_avail_Heartinit);
        SetModifiedAvailCoins(modifiedcoinsinitial);
        SetCoinValue(coinValue);
        StartingPlayerPref();
    }

    private void StartingPlayerPref()
    {
        PlayerPrefs.SetInt("addedCoinsDetails", 1);
    }
    private int GetPlayerinfoin()
    {
        return PlayerPrefs.GetInt("addedCoinsDetails");
    }



    public void SetModifiedAvailCoins(int Coins)
    {

        PlayerPrefs.SetInt("ModifiedAvailCoins", Coins);
    }
    public int GetModifiedAvailCoins()
    {
      return  PlayerPrefs.GetInt("ModifiedAvailCoins");

    }


    public void SetTempAvailCoins(float Coins)
    {
        PlayerPrefs.SetFloat("availCoins", Coins);
    }

    public void SetAvailDiamonds(int diamonds)
    {
        PlayerPrefs.SetInt("availdiamonds", diamonds);
    }

    public void setAvailHearts(int hearts)
    {
        PlayerPrefs.SetInt("availHearts", hearts);
    }


    public void SetCoinValue(float coinvalue)
        {
        PlayerPrefs.SetFloat("CoinsValue", coinvalue);
        }

    public void SetUpdateCoinValue(float coinValue)
    {
        SetCoinValue(GetcoinValue() + coinValue);
    }

    
    public float GetcoinValue()
    {
        return PlayerPrefs.GetFloat("CoinsValue");
    }
    public float  GetTempAvailableCoins()
    {
        return PlayerPrefs.GetFloat("availCoins");
    }
    public int  GetAvailableDiamonds()
    {
        return PlayerPrefs.GetInt("availdiamonds");
    }
    public int GetAvailableHearts()
    {
        return PlayerPrefs.GetInt("availHearts");
    }
}
