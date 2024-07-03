using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    float timmer = 30f;
    public GameObject explodePrefab;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timmer > 0)
        {
            timmer -= Time.deltaTime;
        }
        if (timmer < 0)
            Destroy(gameObject);
    }

    public void Launch(Vector2 direction, float speed)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * speed);
    }


    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.tag == "Enemy") {
            Instantiate(explodePrefab, other.gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Sound.getInstance().PlayeEnemyDeath();
        }
        else if(other.gameObject.tag =="Boss")
        {
            Bear bear = other.gameObject.GetComponent<Bear>();
            bear.GetDamage(1);
        }
        Sound.getInstance().PlayExplode();
        Destroy(gameObject);
    }
} 
