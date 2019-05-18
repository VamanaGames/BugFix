using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPurchaseGateWay : MonoBehaviour
{
    private PlayerCoinsPrefs m_gateway;//this is for payment Available coins that you collected 
    private PlayerPrefPurchase m_purchaseGateway;//this is for purchase amount That is you are colleceted
    private float updateCoinpercentage = 0.1f;
    private float updateDamageEffectvalue = 0.2f;
    private PlayerEnergyPref m_damageupdate;
    void Start()
    {
        m_damageupdate = FindObjectOfType<PlayerEnergyPref>();
        m_gateway = FindObjectOfType<PlayerCoinsPrefs>();
        m_purchaseGateway = FindObjectOfType<PlayerPrefPurchase>();
       
    }

  

    public bool checkPaymentgatewayforCodePerSecond()
    {
        if(m_purchaseGateway.GetUpdateCodePersecond()<m_gateway.GetModifiedAvailCoins())
        {

            //Total amount of COins in coins bar the
            m_gateway.SetModifiedAvailCoins(m_gateway.GetModifiedAvailCoins() - m_purchaseGateway.GetUpdateCodePersecond());
            m_damageupdate.UpdatePlayerbulletReleaseSpeed();
            return true;
        }

        return false;
    }
    public bool ChekpaymentGatewyforCodeReliability()
    {
        if (m_purchaseGateway.GetUpdateCodeReliablility() < m_gateway.GetModifiedAvailCoins())
        {
            //Total amount of COins in coins bar the
            m_gateway.SetModifiedAvailCoins(m_gateway.GetModifiedAvailCoins() - m_purchaseGateway.GetUpdateCodeReliablility());
            m_damageupdate.PlayerUpdateDamagePower(updateDamageEffectvalue);
            return true;
        }
        return false;
    }
    public bool checkPaymentGatewayforCoinsUpgrade()
    {
        if (m_purchaseGateway.GetUpdatedCoinsPercentage() < m_gateway.GetModifiedAvailCoins())
        {



            //Total amount of COins in coins bar the
            m_gateway.SetModifiedAvailCoins(m_gateway.GetModifiedAvailCoins() - m_purchaseGateway.GetUpdatedCoinsPercentage());
            m_gateway.SetUpdateCoinValue(updateCoinpercentage);
            return true;
        }
        return false;
    }
}
