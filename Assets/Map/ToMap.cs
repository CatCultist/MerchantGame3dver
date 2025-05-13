using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMap : MonoBehaviour
{
    public int ExitNumber;
    public Object MapScene;
    public LayerMask _PlayerLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Exit", ExitNumber);
            SceneManager.LoadScene(MapScene.name);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
