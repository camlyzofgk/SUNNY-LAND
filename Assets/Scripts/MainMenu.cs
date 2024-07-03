using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject _loadingCanvas;
    [SerializeField] Image _progressBar;
    [SerializeField] GameObject main;
    private float _target;
    public void Play(){
        SceneManager.LoadScene(1);
    }
    public void Quit(){
        Application.Quit();
    }

    public async void LoadScene(int sceneIndex){
        var scene = SceneManager.LoadSceneAsync(sceneIndex);
        scene.allowSceneActivation = false;
        main.SetActive(false);

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
