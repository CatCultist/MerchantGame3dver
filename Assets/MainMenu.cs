using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("PortVillage");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
