using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public int singleSceneIndex;
    public int multiSceneIndex;

    public void SinglePlayerStart()
    {
        SceneManager.LoadScene(singleSceneIndex);
    }

    public void MultiplayerStart()
    {
        SceneManager.LoadScene(multiSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
