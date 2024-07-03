using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public float displayTime = 4.0f; // thời gian hiển thị 4s
    public GameObject dialogBox; // nơi chứa canvas
    float timerDisplay;
    public int sceneIndex;
    
    void Start()
    {
        dialogBox.SetActive(false); // Set ẩn vùng chat
        timerDisplay = -1.0f;
    }
    
    void Update()
    {
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog() // Hàm dùng hiển thị
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
