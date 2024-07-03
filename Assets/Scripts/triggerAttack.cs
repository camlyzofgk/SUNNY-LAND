using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject parent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // xu ly va cham xuyen qua
    void OnTriggerStay2D(Collider2D other)
    {
        
        parent.GetComponent<piranha>().ToAttackMode();
    }
}
