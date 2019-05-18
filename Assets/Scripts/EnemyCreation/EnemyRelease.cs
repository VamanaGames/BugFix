using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRelease : MonoBehaviour
{

     public GameObject[] smallEnemies;
    public GameObject[] BigEnemies;

    private PlayerCurrentNextPref m_level;
    private int noofplayers=0;
    private bool isBigenemyReleased;
    private float m_minpos=3f;
    private float m_maxpos=-3f;
    private GameManagerController m_gamemanger;
    // Start is called before the first frame update
    void Start()
    {
        m_level = FindObjectOfType<PlayerCurrentNextPref>();
        m_gamemanger = FindObjectOfType<GameManagerController>();
        InvokeRepeating("CallInstiateobject", 1f, 5f);
    }

    private void CallInstiateobject()
    {
        float randtime = Random.Range(3f, 6f);
        Invoke("InstnsiatePlayerObejct", randtime);
    }

    private void InstnsiatePlayerObejct()
    {
        if (!m_gamemanger.getExtraliferesult())
        {
            CheckandRelase();
        }
    }

    private  void CheckandRelase()
    {
        int leveldevide = m_level.GetPlayerCurrentLevel() % 5;
        Debug.Log("deivded value is" + leveldevide);
        if (m_level.GetPlayerCurrentLevel() != 0 && leveldevide == 0)
        {
            Debug.Log("releasedBigEnemy");
            if (!isBigenemyReleased)
                ReleaseBigPlayer();
        }
        else if (noofplayers < m_level.GetPlayerNextLevel())
        {
            Debug.Log("release Small Enemey");
            int randomenem = Random.Range(0, smallEnemies.Length);

            Vector2 temp = transform.position;
            temp.x = Random.Range(m_minpos,m_maxpos);
            transform.position = temp;

            var enemygameObject = Instantiate(smallEnemies[randomenem], transform.position, Quaternion.identity);
            enemygameObject.transform.parent = transform;
            noofplayers++;
        }
    }
    private void ReleaseBigPlayer()
    {
        isBigenemyReleased = !isBigenemyReleased;
        int randpos = Random.Range(0, BigEnemies.Length);

        Vector2 temp = transform.position;
        temp.x = Random.Range(m_minpos, m_maxpos);
        transform.position = temp;

        var bigGgameObject = Instantiate(BigEnemies[randpos], transform.position, Quaternion.identity);
        bigGgameObject.SetActive(true);
        bigGgameObject.transform.parent = transform;

    }


}
