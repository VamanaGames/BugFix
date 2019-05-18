using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyPref : MonoBehaviour
{
    private float initialdamageamount=5f;
    private float timerofReleaseAmountinitial=1f;

    // Start is called before the first frame update
    void Start()
    {
        initiaalizePlayer();
    }

    // Update is called once per frame
    private void initiaalizePlayer()
    {
        if(getAddedData()!=1)
        {
            SetPlayerDamageEffect(initialdamageamount);
            SetPlayerBulletReleaseSpeed(timerofReleaseAmountinitial);
            setAddedData(1);
        }
    }

    public void setAddedData(int value)
    {
        PlayerPrefs.SetInt("AddinitEnergy", value);
    }
    public int getAddedData()
    {

    return  PlayerPrefs.GetInt("AddinitEnergy");

    }

    public void SetPlayerDamageEffect(float value)
    {
        PlayerPrefs.SetFloat("DamageAmount", value);
    }

    public void  PlayerUpdateDamagePower(float value)
    {
        SetPlayerDamageEffect(GetPlayerDamageEffect ()+ value);
    }
    public float GetPlayerDamageEffect()
    {
        return PlayerPrefs.GetFloat("DamageAmount");
    }


    public void SetPlayerBulletReleaseSpeed(float value)
    {
        PlayerPrefs.SetFloat("BulletReleaseSpeed", value);
    }
     public void UpdatePlayerbulletReleaseSpeed()
    {
        SetPlayerBulletReleaseSpeed(GetPlayerBulletReleaseSpeed() / 2);
    }
    public float GetPlayerBulletReleaseSpeed()
    {
         return   PlayerPrefs.GetFloat("BulletReleaseSpeed");
    }
    
}
