using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 endPos;
    public int moveOffset;
    bool isOpen = false;
    float speed = 0.01f;
    void Start()
    {
        endPos = (Vector2)transform.position + Vector2.down*moveOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
            Opening();
    }

    public void Opening()
    {
        Vector2 currentPos = transform.position;
        Vector2 move = endPos - currentPos;
        move.Normalize();
        if((Mathf.Abs(currentPos.y - endPos.y) >= 1))
        {
            
            Vector2 newPos = currentPos += move * speed;
            transform.position = newPos;
        }
    }

    public void Open()
    {
        Sound.getInstance().PlayRockDoor();
        isOpen = true;
    }
}
