using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyHealth : MonoBehaviour
{

    public GameObject particleExplosion;
    private float Health;

    private AmountOfDamage damageamount;
    private LeveLCompletion leveLCompletion;
    private PlayerLevelControl ScoreControl;
    private PlayerCurrentNextPref playernextlevel;

    private PlayerCoinsPrefs diamods;

    private int[] RandvalueofDiamonds = { 25, 30, 45, 50, 55, 65 };

    private int generateRandomDiamonds = 0;
    // Start is called before the first frame update
    void Start()
    {

        diamods = FindObjectOfType<PlayerCoinsPrefs>();
        playernextlevel = FindObjectOfType<PlayerCurrentNextPref>();
        ScoreControl = FindObjectOfType<PlayerLevelControl>();
        leveLCompletion = FindObjectOfType<LeveLCompletion>();
        damageamount = FindObjectOfType<AmountOfDamage>();
        SetHealthdamage();
    }

    private void SetHealthdamage()
    {
        Health = playernextlevel.GetPlayerNextLevel() * 100f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            Debug.Log("Big enemy health is-----"+Health);
            InstansiateParticle(collision.gameObject);
            levelpanelControl();
            damageHealth();
        }
    }

    private void InstansiateParticle(GameObject hitbullet)
    {
        var obj = Instantiate(particleExplosion, hitbullet.transform.position, Quaternion.identity);
     //   obj.transform.parent = transform;
        Destroy(obj, 2f);
        hitbullet.SetActive(false);

    }
    private void levelpanelControl()//for changing  the level bar and score controll
    {
        leveLCompletion.UpdateLevelbarBigEnemy(damageamount.getHelthdamage());//calling another method when bigenemi is called
        ScoreControl.updateScoreui();
    }

    private void damageHealth()
    {

        Health -= damageamount.getHelthdamage();


        if (Health <= 0)
        {
            // InstansiateCoins();//Diamonds instasiate for this Script
            genarateRandomDiamonds();
            Destroy(gameObject);
        }
    }

    private void genarateRandomDiamonds()
    {
        int randDiamods = RandvalueofDiamonds[Random.Range(0, RandvalueofDiamonds.Length)];
        Debug.Log("generate Random Diamonds" + randDiamods);
        //later you have to add
       // diamods.SetAvailDiamonds(randDiamods);
    }

    public float GetBigEnemyHealth()
    {
        return Health;
    }




}
