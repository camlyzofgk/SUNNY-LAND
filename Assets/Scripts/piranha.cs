using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piranha : MonoBehaviour
{
    // Start is called before the first frame update

    Animator anm;
    
    
    void Start()
    {
        anm = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ToAttackMode()
    {
        anm.SetTrigger("attack");
    }



}
