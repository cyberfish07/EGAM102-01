using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    public TMP_Text scoreLabel;

    void Start()
    {
        // Binding event
        ScoreManager.Instance.OnScoreChanged += UpdateScoreDisplay;
        UpdateScoreDisplay(ScoreManager.Instance.CurrentScore);
    }

    void UpdateScoreDisplay(int newScore)
    {
        scoreLabel.text = newScore.ToString();
    }

    void OnDestroy()
    {
        // Cancel binding
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged -= UpdateScoreDisplay;
        }
    }
}