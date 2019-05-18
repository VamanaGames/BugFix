using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LeveLCompletion : MonoBehaviour
{

    private float FillAmount;
    private float GetLevelHealth;
    private int m_No_of_enemys;
    public Image levelfill;
    private PlayerCurrentNextPref m_nextlevel;
    private GameManagerController m_gamemanager;

    private bool callonce;

    // Start is called before the first frame update
    void Start()
    {
        m_gamemanager = FindObjectOfType<GameManagerController>();
        m_nextlevel = FindObjectOfType<PlayerCurrentNextPref>();
   
        m_No_of_enemys = 0;
        levelfill.fillAmount = 0;
        SetLevelHealth();
    }

    // Update is called once per frame
  
    private void SetLevelHealth()
    {
        // GetLevelHealth = 100 * PlayerPrefs.GetInt("Level");

        GetLevelHealth = 100 * (m_nextlevel.GetPlayerNextLevel());
    }

    public void countNoofenEnemys()
    {
        m_No_of_enemys++;
    }
    public void updateLevelbar(float Damageamount)
    {
        float AmountFinished = 1-((GetLevelHealth- Damageamount)/GetLevelHealth);
        Debug.Log("DamageAmount---->" + AmountFinished);
        levelfill.fillAmount += AmountFinished;
    //    Debug.Log("fillAmount--->"+levelfill.fillAmount);
       // levelfill.fillAmount += 0.1f;
        // FillAmount += 10;
        
    }

    public void UpdateLevelbarBigEnemy(float damageamount)
    {
        float AmountFinished = 1 - ((GetLevelHealth - damageamount) / GetLevelHealth);
        Debug.Log("Damageamountbigenemy---->" + AmountFinished);
        levelfill.fillAmount += AmountFinished;
    }
    private void LevelUpdate()
    {
        //add script for level completion in the script
    }
    public float getLevelfillAmount()
    {
        return levelfill.fillAmount;
    }

    private void FixedUpdate()
    {
        Levelamount();
    }

    public void Levelamount()
    {
        if (levelfill.fillAmount > 0.98)
        {

            if (!callonce)
            {
                Debug.Log("Level is Completed");

                m_gamemanager.setlevelComplete(true);
                callonce = !callonce;
            }
        }
    }
    
}
