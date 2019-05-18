    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
 [SerializeField]private float Ballspeed = 1f;
    private GameObject player;
    public GameObject ParticleExplosion;
    public  GameObject CoinsPrefab;
    private float Coinsforce = 5f;

    private bool isPlayerbulletistriggerd;
    private int noofCoins=0;

    private GameManagerController m_gamamanger;
    // Start is called before the first frame update
    void Start()
    {
        m_gamamanger = FindObjectOfType<GameManagerController>();
        player = GameObject.Find("Shooter");
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }
    private void MoveTowardsPlayer()
    {
        if (!m_gamamanger.getExtraliferesult()&&!m_gamamanger.getLevecompletestatus())
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position,
              Ballspeed * Time.deltaTime);
            FocusOfBullet();
        }
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
        isPlayerbulletistriggerd = false;
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0f);
        }
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            ReleaseParticleExplosion();

                if (!isPlayerbulletistriggerd)
                    Instatisiatecoins();

            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
   private  void ReleaseParticleExplosion()
    {
      var particle=  Instantiate(ParticleExplosion, transform.position, Quaternion.identity);
        Destroy(particle, 1f);
    }
   private void Instatisiatecoins()
    {
        Instantiate(CoinsPrefab, transform.position, Quaternion.identity);
        
    }

}
