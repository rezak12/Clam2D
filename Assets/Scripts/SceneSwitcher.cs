using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string MainMenuSceneName = "Main Menu";

    public void ToMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneName);
    }
}
