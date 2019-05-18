using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOneMove : MonoBehaviour
{
    [SerializeField] private float BulletSpeed = 3f;
    private GameObject player;
    public GameObject ParticleExplosion;
    private GameManagerController isextralife;
    void Start()
    {
        isextralife = FindObjectOfType<GameManagerController>();
        player = GameObject.Find("Shooter");
    }

    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {
        if (!isextralife.getExtraliferesult()&&!isextralife.getLevecompletestatus())
        {
            MoveTowardsPlayer();
        }
    }
    private void MoveTowardsPlayer()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position,
            BulletSpeed * Time.deltaTime);
        FocusOfBullet();
    }
    private void FocusOfBullet()
    {
        Vector2 direction = new Vector2(player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y);
        direction.Normalize();
        transform.up = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0f);
        }
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            ReleaseParticleExplosion();
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
    private void ReleaseParticleExplosion()
    {
        var particle = Instantiate(ParticleExplosion, transform.position, Quaternion.identity);
        Destroy(particle, 1f);
    }
  
}
