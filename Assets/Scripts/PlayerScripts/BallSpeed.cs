using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeed : MonoBehaviour
{


    private new Rigidbody2D rigidbody2D;
    [SerializeField] private float BallMoveSpeed;
    public GameObject firepoint;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // rigidbody2D.velocity = rigidbody2D.velocity.normalized * BallMoveSpeed*Time.deltaTime*firepoint.transform.up;
      //  rigidbody2D.velocity =Vector2.up* BallMoveSpeed*Time.deltaTime*firepoint.transform.up;
        rigidbody2D.velocity =Vector2.up* BallMoveSpeed*Time.deltaTime;
     //   rigidbody2D.velocity = firepoint.transform.up;
       
    }
}
