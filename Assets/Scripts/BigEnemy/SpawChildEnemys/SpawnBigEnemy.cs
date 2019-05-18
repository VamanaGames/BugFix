using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBigEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D m_rigidbody2D;
    private float SpawnSpeed = 100f;
    private float m_minx = -3f;
    private float m_maxX = 3f;

    private float m_min_y = -3f;
    private float m_max_y = 4f;
    private int speeddirection;
  [SerializeField ] private float Downspeed = 200f;
   [SerializeField] private float DownSpeedDirection;
    private GameObject mainplayerposition;
    private bool HorizontalSpawn;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        DownSpeedDirection = -1f;
        speeddirection = spawnSpeeddireciton();
        mainplayerposition = GameObject.Find("Shooter");
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        InvokeRepeating("Spwanhorizontal", 5f, 5f);
    }
    void Update()
    {
        spawncontroll();
    }
   

    private void Spwanhorizontal()
    {
        float random = Random.Range(3f, 5f);
        Invoke("Spawnverticle", random);        
            
    }
    private void Spawnverticle()
    {
        HorizontalSpawn = true;
    }

    private void  spawncontroll()
    {
        if (!HorizontalSpawn)
        {
            SpawninngGameObejct();
        }
        else if(HorizontalSpawn)
            {
            downSpawn();
            }
    }

    private int spawnSpeeddireciton()
    {
        speeddirection = Random.Range(-1, 2);
        if(speeddirection==0)
        {
            speeddirection = -1;
        }
        return speeddirection;
    }



    private void SpawninngGameObejct()
    {
        Vector3 targetvelocity= new Vector2(SpawnSpeed * Time.deltaTime * speeddirection, 0f);
        m_rigidbody2D.velocity = Vector3.SmoothDamp(m_rigidbody2D.velocity, targetvelocity, ref velocity, 0.05f);

        if (transform.position.x < m_minx)
        {
            speeddirection = 1;
            Vector2 temp = transform.position;
            temp.x = m_minx;
            transform.position = temp;
        }
        if (transform.position.x > m_maxX)
        {
            speeddirection = -1;
            Vector2 temp = transform.position;
            temp.x = m_maxX;
            transform.position = temp;
        }
    }
    private void downSpawn()
    {
       
        m_rigidbody2D.velocity =new Vector2(0f,1f*Downspeed*Time.deltaTime*DownSpeedDirection);
       
        if (transform.position.y<m_min_y)
        {
            DownSpeedDirection = 1f;
            updatePositionY( m_min_y);
            
        }
        else if(transform.position.y>m_max_y)
        {
            DownSpeedDirection = -1f;
            updatePositionY(m_max_y);
            HorizontalSpawn = false;
        }
    }
    private void updatePositionY(float ypostion)
    {
        Vector2 temp = transform.position;
        temp.y = ypostion;
        transform.position = temp;
    }
}
