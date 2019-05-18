using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public GameObject particleSystem;
    [SerializeField] GameObject CoinsPrefab;
   

    [SerializeField]private float Health = 100f;
    private AmountOfDamage damageamount;
    private LeveLCompletion leveLCompletion;
    private PlayerLevelControl ScoreControl;
    private PlayerCoinsPrefs bigEnemyCoins;
    private PlayerCurrentNextPref m_playerpref;

    private BigEnemyHealth m_getbigEnemyhealth;
    private bool callOnceper;
    private void Start()

    {
        bigEnemyCoins = FindObjectOfType<PlayerCoinsPrefs>();
        ScoreControl = FindObjectOfType<PlayerLevelControl>();
        leveLCompletion = FindObjectOfType<LeveLCompletion>();
        damageamount = FindObjectOfType<AmountOfDamage>();
        m_playerpref = FindObjectOfType<PlayerCurrentNextPref>();
    }
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int count = 0;
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
        
            GameObject particle= Instantiate(particleSystem, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(particle, 3f);
            count++;
            collision.gameObject.SetActive(false);
          if(count==1)
            {
                LevelbarUpdate();
                ScoreControl.updateScoreui();
            }
            damageHealth();

        }
    }

    private void damageHealth()
    {

        Health -= damageamount.getHelthdamage();

        
        if (Health<=0)
        {
            InstansiateCoins();
            Destroy(gameObject);
        }
    }

    void LevelbarUpdate()
    {
        if (m_playerpref.GetPlayerCurrentLevel() % 5 != 0)//except Player In Multiples fo 5
        {
            leveLCompletion.updateLevelbar(damageamount.getHelthdamage());
        }
    }
    private void InstansiateCoins()
    {
        int rand = Random.Range(5, 7);
        Updatecoinsenemykilled(rand);
       for (int i=0;i<rand;i++)
        {
          var coins=  Instantiate(CoinsPrefab, transform.position, Quaternion.identity);

            //coins.GetComponent<Rigidbody2D>().AddForce(new Vector2( Random.Range(0f, 1f)*10f*Time.deltaTime, Random.Range(0f, 1f))*10f*Time.deltaTime,ForceMode2D.Impulse);
            coins.GetComponent<Rigidbody2D>().velocity=new Vector2(Random.Range(0f,1f)*100f*Time.deltaTime,Random.Range(0f,1f)*100f*Time.deltaTime);
        }
    }


    private void Updatecoinsenemykilled(int i)
    {
        bigEnemyCoins.SetModifiedAvailCoins(bigEnemyCoins.GetModifiedAvailCoins() + i);

    }

    private void Update()
    {
        if(m_playerpref.GetPlayerCurrentLevel()%5==0&&m_playerpref.GetPlayerCurrentLevel()>0)
        {
            CheckBigEnemyactiveated();
       //     isBigenemyDestroyed();
        }
    }

    private void isBigenemyDestroyed()

    {
       if( m_getbigEnemyhealth.GetBigEnemyHealth()<=5)
        {
            Destroy(gameObject);
        }
    }

    private void CheckBigEnemyactiveated()
    {
        if (m_playerpref.GetPlayerCurrentLevel() % 5 == 0&&m_playerpref.GetPlayerCurrentLevel()>0)
        {
            var obj = GameObject.Find("BigEnemy");
            if (obj != null)
            {
                if (!callOnceper)
                {
                    m_getbigEnemyhealth = FindObjectOfType<BigEnemyHealth>();
                    callOnceper = !callOnceper;
                }
                isBigenemyDestroyed();
            }
        }
    }

}
