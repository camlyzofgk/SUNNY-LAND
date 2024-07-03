using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 1000;
    Rigidbody2D rb;
    Animator animator;
    
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("direction",rb.velocity.x);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            move player = collision.GetComponent<move>();
            player.ChangeHealth(-2);
            
        }
        Sound.getInstance().PlayerFireBallHit();
        Destroy(gameObject);
    }


    public void Launch(Vector2 direction)
    {   
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(speed * direction);
    }


}
