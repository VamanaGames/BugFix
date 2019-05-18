using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{

  private float addVelocityForce = 60f;
  [SerializeField]public GameObject positionofCoins;
    private bool isMovingCoinsPos = false;
    private float Coinspeed=10f;

    private int noofcalls = 0;
    private bool isCoinsCollectedcall = false;
//this is also playerprefences later you have to add

    private CoinsUpdated m_coinsCollected;
    void Start()
    {
        m_coinsCollected = FindObjectOfType<CoinsUpdated>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -transform.position.y*addVelocityForce*Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isCoinsCollectedcall = false;
        noofcalls = 0;
       Debug.Log("collision iin the game object--->"+collision.gameObject.name);
         if(collision.gameObject.CompareTag("Player"))
        {
            DeactivateBoXCollide();
            isMovingCoinsPos = true;
         //   gameObject.SetActive(false);
        }
    }
    private void DeactivateBoXCollide()
    {
        gameObject.GetComponent<Collider2D>().enabled=false;
        UpdateCoinsValue();
    }
    private void movetoCoinsPosition()
    {
        if (isMovingCoinsPos)
        {
           
            transform.position = Vector2.MoveTowards(transform.position,
           positionofCoins.transform.position,
           Coinspeed * Time.deltaTime);
            if(transform.position==positionofCoins.transform.position)
            {
                gameObject.SetActive(false);
            }
        }
    }
    private void FixedUpdate()
    {
        movetoCoinsPosition();
    }

    private void UpdateCoinsValue()
    {
        noofcalls++;
        Debug.Log("Call no of times " + noofcalls);

        if (!isCoinsCollectedcall)
        {
            
            m_coinsCollected.updateCoinsScore();
            isCoinsCollectedcall = true;
        }
    }



}
