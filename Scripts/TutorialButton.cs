using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    // Load tutorial scene
    public void Tutorial()
    {
        SceneManager.LoadScene("Info");
    }
}