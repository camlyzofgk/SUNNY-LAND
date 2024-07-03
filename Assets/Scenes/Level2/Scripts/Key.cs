using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Bắt đầu va chạm
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            move player = other.GetComponent<move>();
            player.getKey();
            Destroy(gameObject);
            Sound.getInstance().PlayKeyPickUp();
        }
    }

}
