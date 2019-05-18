using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectPooling : MonoBehaviour
{

    public GameObject m_bullet;
    public int Noofbullets;
    private List<GameObject> bullets;
    public GameObject firepoint;
    public GameObject SpawnPosition;
    // Start is called before the first frame update
    void Awake()
    {
        bullets = new List<GameObject>();
        instansiatebullets();
    }

    private void instansiatebullets()
    {
        for (int i=0;i<Noofbullets;i++)
        {
            var obj = Instantiate(m_bullet, firepoint.transform.position, Quaternion.identity);
            obj.transform.parent = SpawnPosition.transform;
            obj.SetActive(false);
            bullets.Add(obj);
        }
    }
    public void ReleaseBullets()
    {
        int count = 0;
        for (int i= 0;i < bullets.Count;i++)
        {
            if(!bullets[i].activeInHierarchy)
            {

                bullets[i].transform.position = firepoint.transform.position;
                bullets[i].SetActive(true);
                Debug.Log("hello you called --this one is --" + count);
                break;
             //   return bullets[i];
             //   bullets[i].GetComponent<Rigidbody2D>().velocity = firepoint.transform.up;
                
                
            }
        }
     //   return null;
    }
}
