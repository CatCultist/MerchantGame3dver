using UnityEngine;
[System.Serializable]
public class MapManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 
    

   

   
    public AvailableLocals[] Location= new AvailableLocals[4];


    private GameObject[] buttons;
    // Update is called once per frame
    private void Start()
    {
        if (buttons == null)
        {
            buttons = GameObject.FindGameObjectsWithTag("Buttons");
        }
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
        foreach(GameObject local in Location[PlayerPrefs.GetInt("Exit")].Close)
        {
            local.SetActive(true);
        }
    }
    void Update()
    {
        
    }
}
