using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundParallax : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 startPos;
    public float ratio;


    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + GameConfig.GetInstance().player.getOffset()*ratio;
    }


}
