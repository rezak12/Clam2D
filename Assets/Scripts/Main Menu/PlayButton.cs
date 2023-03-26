using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    AsyncOperation sceneLoadingOperation;
    private void Start()
    {
        sceneLoadingOperation =
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        sceneLoadingOperation.allowSceneActivation = false;
    }

    public void LoadScene()
    {
        sceneLoadingOperation.allowSceneActivation = true;
    }
}
