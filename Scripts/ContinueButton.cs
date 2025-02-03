using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    // Load MainGame scene
    public void Continue()
    {
        SceneManager.LoadScene("MainGame");
    }
}
