using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifeDeactiveEnemybullets : MonoBehaviour
{
    private int counter;
    private GameObject m_playerposition;
    private void Start()
    {
        m_playerposition = GameObject.Find("Shooter");
        counter = 0;
        InvokeRepeating("deactiveAftersometime", 0, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("after Extra life");
            Destroy(collision.gameObject);
        }
    }


    private void deactiveAftersometime()
    {
        counter++;
        if(counter>2)
        {
            gameObject.SetActive(false);
        }

    }
    private void Update()
    {
        PlayerPosition();
    }
    private  void PlayerPosition()
    {
        transform.position = m_playerposition.transform.position;
    }
}
