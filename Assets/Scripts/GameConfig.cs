using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-10)]

public class GameConfig : MonoBehaviour
{
    // Start is called before the first frame update

    static GameConfig instance;
    int stars = 0;
    int point = 0;
    public move player;
    


    
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainPoint()
    {
        point++;
    }


    public void GainStar()
    {
        stars+=2;
    }

    public bool UseStar()
    {
        if(stars != 0)
        {
            stars--;
            return true;
        }
        return false;
    }

    public int GetCurrentStar()
    {
        return stars;
    }

    public static GameConfig GetInstance()
    {
        return instance;
    } 
}
