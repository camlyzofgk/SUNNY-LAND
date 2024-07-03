using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour // Dùng để quản lý các sự kiện
{
    public static LevelManager instance;
    UIManager _ui;

    private void Awake()
    {
        if (LevelManager.instance == null) instance = this;
        else Destroy(gameObject);
        _ui = GetComponent<UIManager>();
    }

    public void GameOver()
    {
        if (_ui != null)
        {
            _ui.ToggleDeathPanel();
        }
    }
    public void LoadScene(int sceneIndex){
        if (_ui != null)
        {
            
            _ui.LoadScene(sceneIndex);
        }
    }
    //public void MainMenu(){
    //    SceneManager.LoadScene(0);
    //}
    public void MainMenu()
    {
        Debug.Log("MainMenu method called");
        SceneManager.LoadScene(0); // Load Main Menu scene
    }

}
