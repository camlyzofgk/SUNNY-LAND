using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TremorActive : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tremorDameZonePrefab;
    Vector2 direction;
    int numberOfTremor = 20;
    float timeBetween = 0.025f;
    int tremorLeft;
    float timeLeft;
    int index = 0;
    Rigidbody2D rb;
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
       

        if (timeLeft > 0)
            timeLeft -= Time.deltaTime;
        else if ( tremorLeft > 0)
        {
            tremorLeft -= 1;
            Instantiate(tremorDameZonePrefab, (Vector2)transform.position + (direction * index), Quaternion.identity);
            index++;
            timeLeft = timeBetween;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Active(Vector2 direction )
    {
        tremorLeft = numberOfTremor;
        index = 0;
        this.direction = direction;
        this.direction.Normalize();
    }

   
}
