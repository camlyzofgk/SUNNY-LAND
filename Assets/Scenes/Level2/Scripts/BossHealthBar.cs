using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Image mask;
    float originalSize;
    

    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
        
    }

    public void SetValue(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }


    
}
