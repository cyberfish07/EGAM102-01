using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // Load tutorial scene
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}