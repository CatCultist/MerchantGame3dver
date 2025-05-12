using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMap : MonoBehaviour
{
    public int ExitNumber;
    public Object MapScene;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Exit", ExitNumber);
        SceneManager.LoadScene(MapScene.name);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
