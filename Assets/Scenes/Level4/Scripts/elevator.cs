using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    float _speed;
    [SerializeField] Transform s, e;
    Rigidbody2D rb;
    public float speed{
        get{
            return _speed;
        }
        set{
            _speed = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _speed = 0.0f;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_speed != 0){
            if(transform.position.y > e.position.y){
                _speed = -5.0f;
            }
            if(transform.position.y < s.position.y){
                _speed = 5.0f;
            }
        }
    }

    void FixedUpdate(){
        transform.position += (Vector3.up * _speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D c){
        if(c!=null){
            if(c.gameObject.tag == "Elevator"){
                _speed *= -1;
            }
        }
    }
}
