using UnityEngine;

public class Start : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject gameMenu;

    public void StartGame()
    {
        startMenu.SetActive(false);
        gameMenu.SetActive(true);
    }
}
