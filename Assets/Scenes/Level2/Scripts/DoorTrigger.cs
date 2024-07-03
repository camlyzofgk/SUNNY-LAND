using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door;
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
            if(player.isHasKey())
            {
                Sound.getInstance().PlayKeyUse();
                OpenDoor();
                player.useKey();
            }
        }
    }


    void OpenDoor() 
    {
        Door door = this.door.GetComponent<Door>();
        door.Open();
    }
}
