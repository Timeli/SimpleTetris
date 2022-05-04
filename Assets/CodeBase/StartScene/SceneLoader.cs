using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    private const string MainScene = "Main";

    public Button PlayButton;

    private void Start() =>
        PlayButton.onClick.AddListener(LoadMainScene);

    private void OnDisable() => 
        PlayButton.onClick.RemoveListener(LoadMainScene);

    private void LoadMainScene() =>
        SceneManager.LoadScene(MainScene);
}
