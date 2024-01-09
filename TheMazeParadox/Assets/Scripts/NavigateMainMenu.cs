using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateMainMenu : MonoBehaviour
{
    public string sceneName;
    public void goToScene() {
        SceneManager.LoadScene(sceneName);
    }

    public void exitGame() {
        Application.Quit();
    }
}
