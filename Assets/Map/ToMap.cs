using UnityEngine;

public class ToMap : MonoBehaviour
{
    public int ExitNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Exit", ExitNumber);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
