using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiveHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        move player = other.GetComponent<move>();
        if(player != null)
        {
            if(player.getCurrentHealth() < player.getMaxHealth())
            {
                player.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
