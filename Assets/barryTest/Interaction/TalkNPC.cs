using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkNPC : MonoBehaviour, I_Interactable
{
    public InventoryController _Inventory;
    public int _Cost;

    void Start()
    {
        _Inventory = GameObject.Find("Player").GetComponent<InventoryController>();
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("WORK DAMN YOU");
        SceneManager.LoadScene("ciaranscene");
        return true;
    }
}
