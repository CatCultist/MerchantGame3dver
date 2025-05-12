using UnityEngine;

public class TalkNPC : MonoBehaviour, I_Interactable
{



    private GameObject _PlayerObj;
    private GameObject _UiControl;
    public NpcObj _NpcObj;

    void Start()
    {
        _PlayerObj = GameObject.Find("Player");
        _UiControl = GameObject.Find("UI");
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log(_NpcObj);
        _UiControl.GetComponent<uiController>()._NpcDialogue = _NpcObj;
        _UiControl.GetComponent<uiController>().TalkUI();


        return true;
    }
}
