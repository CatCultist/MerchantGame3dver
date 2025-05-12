using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLocal : MonoBehaviour
{
    public Object Scene;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ChangeLocal()
    {

        SceneManager.LoadScene(Scene.name);
    }

}
