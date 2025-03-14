using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkNPC : MonoBehaviour, I_Interactable
{
    public InventoryController _Inventory;
    public int _Cost;
    private GameObject _PlayerObj;

    void Start()
    {
        _PlayerObj = GameObject.Find("Player");
        _Inventory = _PlayerObj.GetComponent<InventoryController>();
    }

    public bool Interact(Interactor interactor)
    {
        _PlayerObj.GetComponent<PlayerControlScript>()._PreviousPosition = _PlayerObj.transform.position;
        _PlayerObj.GetComponent<PlayerControlScript>()._PreviousScene = SceneManager.GetActiveScene().name;
        _PlayerObj.GetComponent<PlayerControlScript>().PauseGame();
        Debug.Log("WORK DAMN YOU");
        SceneManager.LoadScene("ciaranscene");

        return true;
    }
}
