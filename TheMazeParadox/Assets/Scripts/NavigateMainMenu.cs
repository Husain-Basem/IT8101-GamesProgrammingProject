using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateMainMenu : MonoBehaviour
{
    public void goToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void exitGame() {
        Application.Quit();
    }
}
