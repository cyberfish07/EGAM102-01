using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private int _currentScore;
    // Get the figure
    public int CurrentScore
    {
        get => _currentScore;
        set
        {
            _currentScore = value;
            OnScoreChanged?.Invoke(_currentScore);
        }
    }

    // Score change
    public delegate void ScoreChangedHandler(int newScore);
    public event ScoreChangedHandler OnScoreChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Listen the scene status
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Cancel event
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainGame")
        {
            ResetScore();
        }
    }

    public void AddScore(int points)
    {
        CurrentScore += points;
    }

    public void ResetScore()
    {
        CurrentScore = 0;
    }
}