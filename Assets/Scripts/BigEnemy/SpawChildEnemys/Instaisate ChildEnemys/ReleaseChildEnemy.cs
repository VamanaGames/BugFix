using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseChildEnemy : MonoBehaviour
{

    public GameObject[] ChildEnemys;
    private int MaxnoOfenemey;
    private int noofObjectsReleased;
    float randtime;
    // Start is called before the first frame update
    private PlayerCurrentNextPref m_currentlevel;
    private GameManagerController m_gameManager;

    void Start()
    {
        m_currentlevel = FindObjectOfType<PlayerCurrentNextPref>();
        m_gameManager = FindObjectOfType<GameManagerController>();
        InvokeRepeating("CallReleasechildEnemy", 0.1f, 5f);
        MaxnoOfenemey = m_currentlevel.GetPlayerNextLevel();
    }

    private void CallReleasechildEnemy()
    {
        randtime = Random.Range(10f, 20f);
        Invoke("CheckandRelease", randtime);
    }
    private void ReleaseChildenemyobj()
    {
        if (noofObjectsReleased < MaxnoOfenemey)
        {

            int randenemy = Random.Range(0, ChildEnemys.Length);
            Instantiate(ChildEnemys[randenemy], transform.position, Quaternion.identity);
            noofObjectsReleased++;
        }
    }
    private void CheckandRelease()
    {
        if(!m_gameManager.getExtraliferesult())
        {
            ReleaseChildenemyobj();
        }
    }
}
