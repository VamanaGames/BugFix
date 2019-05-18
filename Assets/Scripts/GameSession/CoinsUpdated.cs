using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsUpdated : MonoBehaviour
{
    private int m_coinsArchived = 0;
    private PlayerCoinsPrefs m_coinsupdated;
   

    // Start is called before the first frame update
    void Start()
    {
    
        m_coinsupdated = FindObjectOfType<PlayerCoinsPrefs>();
    }
    public void updateCoinsScore()
    {

        m_coinsupdated.SetTempAvailCoins(m_coinsupdated.GetTempAvailableCoins() +(m_coinsupdated.GetcoinValue()));
        
         float m_coinsArchived = m_coinsupdated.GetTempAvailableCoins();

        m_coinsupdated.SetModifiedAvailCoins((int)Mathf.Ceil(m_coinsArchived));

        Debug.Log("Coins value is--->" + m_coinsupdated.GetModifiedAvailCoins());
        }

    public void updateDimondsScore( int value)
    {
        m_coinsupdated.SetAvailDiamonds(m_coinsupdated.GetAvailableDiamonds() + value);
        Debug.Log("availAbleDimonds" + m_coinsupdated.GetAvailableDiamonds());
    }
    public void updateHearts(int value)
    {
        m_coinsupdated.setAvailHearts(m_coinsupdated.GetAvailableHearts() + value);
        Debug.Log("avail Heartss" + m_coinsupdated.GetAvailableHearts());
    }

}
