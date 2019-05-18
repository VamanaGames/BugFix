using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroling : MonoBehaviour
{
   [SerializeField]private float Mindistancce ;

    private GameObject PlayerGameObject;
    [SerializeField]private float spawn_min_positon = -5f;
    [SerializeField]private float spawn_Max_positon = 5f;
    private Rigidbody2D enemy_rigidBody2d;
    [SerializeField] private float SpawnSpeed=100f;

    [SerializeField]private float speedDirection ;

    private float MoveSpeed =1f;

    // Start is called before the first frame update
    void Start()
    {
    

        Mindistancce = Random.Range(5f, 8f);
        speedDirection = Random.Range(-1, 2);
        PlayerGameObject = GameObject.Find("Shooter");

        enemy_rigidBody2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("ChangeSpawnDirection", 5f, 5f);
        
    }
    

    private void FixedUpdate()
    {
        MoveTowordsPlayre();
        SpawninngGameObejct();
    }
    private void MoveTowordsPlayre()
    {
        float range = Vector2.Distance(transform.position, PlayerGameObject.transform.position);

        if (range > Mindistancce)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, PlayerGameObject.transform.position, MoveSpeed * Time.deltaTime);
        }
        if (range < Mindistancce - 1f)
        {
            speedDirection = Random.Range(-1, 2);
            transform.position = Vector2.MoveTowards(transform.position, PlayerGameObject.transform.position, -MoveSpeed * Time.deltaTime);

        }
    }
    private void SpawninngGameObejct()
    {
        enemy_rigidBody2d.velocity = new Vector2(SpawnSpeed * Time.deltaTime * speedDirection, 0f);
        if (transform.position.x < spawn_min_positon)
        {
            speedDirection = 1f;
            Vector2 temp = transform.position;
            temp.x = spawn_min_positon;
            transform.position = temp;
        }
        if (transform.position.x > spawn_Max_positon)
        {
            speedDirection = -1f;
            Vector2 temp = transform.position;
            temp.x = spawn_Max_positon;
            transform.position = temp;

        }
        
    }
    private void ChangeSpawnDirection()
    {
        speedDirection = Random.Range(-1, 1);
        if(speedDirection==0)
        {
            speedDirection = 1;
        }
    }
}
