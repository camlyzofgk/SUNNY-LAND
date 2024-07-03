using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject DeathPanel;
    [SerializeField] GameObject HealthBar;
    [SerializeField] GameObject Star;
    [SerializeField] GameObject ButtonPause;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject player;
    [SerializeField] GameObject _loadingCanvas;
    [SerializeField] Image _progressBar;
    private float _target;
    public static UIManager instance;

    void Awake(){
        instance = this;
    }

    public void ToggleDeathPanel(){ 
        DeathPanel.SetActive(!DeathPanel.activeSelf); //Hiển thị deathpanel
        HealthBar.SetActive(!HealthBar.activeSelf); // Ẩn thanh máu
        Star.SetActive(!Star.activeSelf); // Ẩn ngôi sao
        ButtonPause.SetActive(!ButtonPause.activeSelf); //Ẩn nút pause
        player.SetActive(!player.activeSelf); // Ẩn người chơi
    }
    public void TogglePausePanel(){
        HealthBar.SetActive(!HealthBar.activeSelf);
        Star.SetActive(!Star.activeSelf);
        ButtonPause.SetActive(!ButtonPause.activeSelf);
        PausePanel.SetActive(!PausePanel.activeSelf);
        player.SetActive(!player.activeSelf); // Ẩn người chơi

    }
    public void Restart(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public async void LoadScene(int sceneIndex){
        var scene = SceneManager.LoadSceneAsync(sceneIndex);
        scene.allowSceneActivation = false;

        _loadingCanvas.SetActive(true);

        do {
            await Task.Delay(100);
            _target = scene.progress;
        }while(scene.progress < 0.9f);

        await Task.Delay(1000);

        scene.allowSceneActivation = true;
        _loadingCanvas.SetActive(false);
    }
    void Update(){
        _progressBar.fillAmount = Mathf.MoveTowards(_progressBar.fillAmount, _target, 3*Time.deltaTime);
    }
}
