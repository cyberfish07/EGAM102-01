using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // Load tutorial scene
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
}