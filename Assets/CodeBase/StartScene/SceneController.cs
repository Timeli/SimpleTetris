using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    private const string MainScene = "Main";
    private const string StartScene = "StartScene";

    public Button RestartButton;
    public Button ExitButton;

    private void Start()
    {
        RestartButton.onClick.AddListener(RestartMainScene);
        ExitButton.onClick.AddListener(ReturnStartScene);
    }

    private void OnDisable()
    {
        RestartButton.onClick.RemoveListener(RestartMainScene);
        ExitButton.onClick.RemoveListener(ReturnStartScene);
    }

    private void ReturnStartScene() => 
        SceneManager.LoadScene(StartScene);

    private void RestartMainScene() => 
        SceneManager.LoadScene(MainScene);
}
