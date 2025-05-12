
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneChange : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Object scene;
    void Start()
    {
        
    }

    // Update is called once per frame
   
    public void SceneChanger()
    {
        SceneManager.LoadScene(scene.name);
    }
    void Update()
    {
        
    }
}
