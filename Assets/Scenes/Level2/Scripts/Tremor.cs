using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tremor : MonoBehaviour
{
    // Start is called before the first frame update
    float timeExist = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeExist -= Time.deltaTime;
        if(timeExist < 0)
            Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            move player = collision.GetComponent<move>();
            player.ChangeHealth(-2);
        }

    }
}
