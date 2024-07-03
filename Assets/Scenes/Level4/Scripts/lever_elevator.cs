using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever_elevator : MonoBehaviour
{
    [SerializeField] GameObject elevator;
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D c){
        if(c != null){
            if(c.gameObject.tag == "Player"){
                if(elevator != null){
                    elevator.GetComponent<elevator>().speed = 5.0f;
                    ani.SetInteger("click",1);
                }
            }
        }
    }
}
