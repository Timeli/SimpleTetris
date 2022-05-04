using UnityEngine;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField]
    private Activator _activator;

    [SerializeField]
    private PauseButton _pauseButton;

    public void Activate(int bestResult, int currentResult)
    {
        _pauseButton.Button.interactable = false;

        _activator.ShowGameOverScreen(bestResult, currentResult);
    }
}
