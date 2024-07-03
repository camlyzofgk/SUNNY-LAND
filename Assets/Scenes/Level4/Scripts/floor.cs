using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor : MonoBehaviour
{
    float timeDown, p, timeDestroy = 1.0f;
    [SerializeField] GameObject explodePrefab;

    private Vector3 originalPosition;
    private bool isShaking;
    private float shakeDuration;
    private float shakeFrequency = 0.03f;
    private float shakeMagnitude = 0.03f;

    private void Start()
    {
        originalPosition = transform.position;
        timeDown = timeDestroy;
        p = 0;
        isShaking = false;
    }

    private void Update()
    {
        if(isShaking){
            Shake();
        }
        timeDown -= Time.deltaTime * p;
        if(timeDown < 0){
            Instantiate(explodePrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Shake(){
        shakeDuration -= Time.deltaTime;
        if (shakeDuration > 0)
        {
            transform.Translate(Vector3.right * Mathf.Sin(Time.time * shakeFrequency) * shakeMagnitude);
        }
        else
        {
            shakeDuration = 0.1f;
            transform.position = originalPosition;
        }

    }

    void OnCollisionEnter2D(Collision2D c){
        if(c!=null){
            if(c.gameObject.tag == "Player"){
                isShaking = true;
                p = 1;
            }
        }
    }

    void OnCollisionExit2D(Collision2D c){
        if(c!=null){
            if(c.gameObject.tag == "Player"){
                isShaking = false;
                p = 0;
                timeDown = timeDestroy;
            }
        }
    }
}
