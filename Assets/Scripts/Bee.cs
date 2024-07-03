using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    float speed = 2.0f;
    Animator anm;
    public float horizontal = -1;
    float changeDirectionTime = 3;
    float timmer;
    void Start()
    {
        timmer = changeDirectionTime;
        rb = GetComponent<Rigidbody2D>();
        anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timmer -= Time.deltaTime;
        if(timmer < 0)
        {
            timmer = changeDirectionTime;
            horizontal = -horizontal;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        anm.SetFloat("horizontal", horizontal);
    }
}
