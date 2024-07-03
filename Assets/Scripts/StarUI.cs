using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StarUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;
    public GameObject key;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Change(GameConfig.GetInstance().GetCurrentStar());
        ChangeKey();
    }

    void Change(int star)
    {
        string count = "x" + star;
        text.text = count;
    }
    void ChangeKey()
    {
        bool isHasKey = GameConfig.GetInstance().player.isHasKey();
        key.SetActive(isHasKey);
    }
}
