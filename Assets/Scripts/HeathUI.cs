using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeathUI : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;
    public GameObject health4;
    public GameObject health5;
    static HeathUI instance;



    GameObject[] healthBar;

    void Start()
    {
        healthBar = new GameObject[5] { health1, health2, health3, health4, health5 };
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change(int h)
    {
        for(int i = 0; i < 5; ++i)
        {
            if(i + 1 <= h )
            {
                healthBar[i].SetActive(true);
            }
            else healthBar[i].SetActive(false);
        }
    }


    public static HeathUI GetInstance()
    {
        return instance;
    }

}
