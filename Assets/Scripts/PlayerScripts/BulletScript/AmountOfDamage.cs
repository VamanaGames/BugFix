using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountOfDamage : MonoBehaviour
{
    public static float Healthdamage ;

    private PlayerEnergyPref m_playerenergy;
    // Start is called before the first frame update
    void Start()
    {
        m_playerenergy = FindObjectOfType<PlayerEnergyPref>();
        Healthdamage = m_playerenergy.GetPlayerDamageEffect();
    }
    public float getHelthdamage()
    {
        Debug.Log("Damage effect is" + m_playerenergy.GetPlayerDamageEffect());
        return m_playerenergy.GetPlayerDamageEffect();
    }

    
}
