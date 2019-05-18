    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsFireControll : MonoBehaviour
{

    [SerializeField] private GameObject FireBullets;

    public GameObject FirePoint;
    private float Timerrelease;
    private float countTempTimer;
    [Range(0, 1)][SerializeField]  float timerreleaseontrol;
    private PlayerObjectPooling m_getbulletObject;

    private GameManagerController m_game_manager;
    private PlayerEnergyPref waittiletoRelease;
    // Start is called before the first frame update
    private void Awake()
    {
       
    }
    void Start()
    {
        m_getbulletObject = FindObjectOfType<PlayerObjectPooling>();
        waittiletoRelease = FindObjectOfType<PlayerEnergyPref>();
        timerreleaseontrol = waittiletoRelease.GetPlayerBulletReleaseSpeed();
        m_game_manager = FindObjectOfType<GameManagerController>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!m_game_manager.getGameOver())
        {
            if (!m_game_manager.getExtraliferesult())
            {
                TimerCounter();
            }
        }
        if(Input.GetMouseButtonDown(0))
        {

         //   ReleaseBall();
        }
    }
 
 
    private void  TimerCounter()
    {
        Timerrelease = timerreleaseontrol;

        countTempTimer += Time.deltaTime;

        if(countTempTimer>Timerrelease)
       {
            ReleaseBall();
            countTempTimer = 0;
        }
    }

    private void ReleaseBall()
    {
         // if (m_getbulletObject.ReleaseBullets() != null)
          //{
            // var balll = Instantiate(m_getbulletObject.ReleaseBullets(), FirePoint.transform.position, Quaternion.identity);
            // Vector2 shootdir = ShootDirection();//use mouse and playergun used for control
            m_getbulletObject.ReleaseBullets();//.GetComponent<Rigidbody2D>().velocity = (FirePoint.transform.up);
        // }
        //m_getbulletObject.ReleaseBullets();
    }

    public Vector2 ShootDirection()
    {
        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mouseposition.x - FirePoint.transform.position.x,
           mouseposition.y - FirePoint.transform.position.y);

        direction.Normalize();
        return direction;
    }


    

}
