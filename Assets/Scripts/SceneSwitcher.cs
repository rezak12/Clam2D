using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string MainMenuSceneName = "MainMenu";

    public void ToMainMenu()
    {
        SceneManager.LoadScene(MainMenuSceneName);
    }
}
