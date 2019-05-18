using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update

    private int noOfhits;
    private int maxNoofhits = 3;
    private GameManagerController m_gameStatus;
    private bool CallOnlyOnceperGame;

    private PanelControl m_controExtraLife;
    private void Start()
    {
        CallOnlyOnceperGame = false;
        m_controExtraLife = FindObjectOfType<PanelControl>();
        m_gameStatus = FindObjectOfType<GameManagerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            DamagePlayer();
        }
    }

    public void  DamagePlayer()
    {
        noOfhits++;
    }
    private void FixedUpdate()
    {
        CheckPlayerDied();

    }
    private void CheckPlayerDied()
    {
        if(noOfhits>maxNoofhits)
        {

            if(CallOnlyOnceperGame)
            {
                Debug.Log("no of times runs");
               m_controExtraLife.setActiveGameOverPannel();
            }
            else if(!CallOnlyOnceperGame)
            {

                m_controExtraLife.setExtraLifePanel();
                m_gameStatus.SetExtralifeoption(true);
                CallOnlyOnceperGame = !CallOnlyOnceperGame;
                SetnofHitsDecrease();
            }
            //    m_gameStatus.setGameOverinfo(true);//Call Extra life pannel 
            //after calling extra life panel you have if he clicked extra life pannel  you have to givechance to play game 
        }
    }
    public void SetnofHitsDecrease()
    {
        noOfhits--;
    }
}
