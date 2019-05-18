using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterSpawning : MonoBehaviour
{

  
    private float movement;
   [SerializeField] private float movementSpeed = 100f;
    private   Rigidbody2D m_rigidBody2d;
    private float min_clamp_position=-3f;
    private float max_clamp_position=3f;

    private Vector3 velocity = Vector3.zero;
    [Range(0, 3f)] [SerializeField] private float MovementSmoothing = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // RotationOfGuide();
        SlideShooter();
        Clamp(); 
     
    }


    private void RotationOfGuide()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        direction.Normalize();
        transform.up = direction;
    }
  
    private void SlideShooter()
    {

        movement = Input.GetAxisRaw("Horizontal");
        if(movement<0)
        {
            Movemetplayer(movement * movementSpeed);
           

        }
        if (movement>0)
        {
            Movemetplayer(movement * movementSpeed);

        }

    }

    private void Movemetplayer(float movespeed)
    {
        m_rigidBody2d.velocity = new Vector2(movespeed , m_rigidBody2d.velocity.y);
  //      m_rigidBody2d.velocity = Vector3.SmoothDamp(m_rigidBody2d.velocity,targetVelocity, ref velocity, MovementSmoothing);
    }

     // And then smoothing it out and applying it to the character
   
    private void Clamp()
    {
        Vector2 temp = transform.position;
        if(temp.x<min_clamp_position)
        {
            temp.x = min_clamp_position;
        }
        if(temp.x>max_clamp_position)
        {
            temp.x = max_clamp_position;
        }
        transform.position = temp;
        
    }
}
