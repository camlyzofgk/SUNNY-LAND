using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeToDestroy = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToDestroy > 0f)
        {
            timeToDestroy -= Time.deltaTime;
        }
        else Destroy(gameObject);
    }
}
