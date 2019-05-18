using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]private GameObject[] EneyBullets;


    private GameManagerController m_game_manager;
   
    void Start()
    {
        m_game_manager = FindObjectOfType<GameManagerController>();
        InvokeRepeating("ChangeShoottime", 0.1f, 5f);
    }

    private void  ChangeShoottime()
    {
            float randtime = Random.RandomRange(2f, 4f);
            Invoke("releaseGameObejct", randtime);
        
    }
    private void releaseGameObejct()
    {

        if (!m_game_manager.getGameOver())
        {
            if (!m_game_manager.getExtraliferesult())
            {
                var gameobeject = Instantiate(EneyBullets[Random.Range(0, EneyBullets.Length)], transform.position, Quaternion.identity);
            }
        }
    }
   
    

    
}
