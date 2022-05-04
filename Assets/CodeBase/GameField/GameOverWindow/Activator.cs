using TMPro;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public TMP_Text BestResult;
    public TMP_Text YourResult;

    public void ShowGameOverScreen(int bestResult, int currentResult)
    {
        SetResults(bestResult, currentResult);

        gameObject.SetActive(true);
    }

    private void SetResults(int bestResult, int currentResult)
    {
        BestResult.text = $"Best: {bestResult}";
        YourResult.text = $"Your: {currentResult}";
    }
}
