using Assets.CodeBase.Data;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BestResult : MonoBehaviour
{
    public TMP_Text BestScore;

    public Button ResetButton;

    private SaverService _saverService;

    private void Start()
    {
        _saverService = new SaverService();
        
        LoadBestScore();

        ResetButton.onClick.AddListener(ResetScore);
    }
    
    private void OnDisable() =>
        ResetButton.onClick.RemoveListener(ResetScore);

    private void LoadBestScore()
    {
        _saverService.LoadSaveFile();
        BestScore.text = _saverService.CurrentBestScore.ToString();
    }

    private void ResetScore()
    {
        _saverService.ResetScore();
        BestScore.text = "0";
    }
}
