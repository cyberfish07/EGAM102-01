using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Load MainGame scene
    public void startGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
