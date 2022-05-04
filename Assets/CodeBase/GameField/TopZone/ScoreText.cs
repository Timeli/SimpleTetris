using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TMP_Text Score;

    private int _scoreBefore;
    private int _difference;

    public Color WhiteColor;
    public Color GreenColor;

    private void Start() => 
        Score.color = WhiteColor;

    public void UpdateScore(int score)
    {
        _difference = score - _scoreBefore;
        Score.color = GreenColor;
        
        Score.text = $"+{_difference}";

        StartCoroutine(ChangeScore(score));
        _scoreBefore = score;
    }

    private IEnumerator ChangeScore(int score)
    {
        yield return new WaitForSeconds(1f);
        Score.color = WhiteColor;
        Score.text = $"{score}";
    }
}
