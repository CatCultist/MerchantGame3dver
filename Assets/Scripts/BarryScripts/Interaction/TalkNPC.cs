using GameplaySystems.Merchant;
using UnityEngine;

public class TalkNPC : MonoBehaviour, I_Interactable
{



    private GameObject _PlayerObj;
    private GameObject _UiControl;
    public NpcObj _NpcObj;


    void Awake()
    {
        _PlayerObj = GameObject.Find("Player");
        _UiControl = GameObject.Find("UI");

    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log(_NpcObj);
        _UiControl.GetComponent<uiController>()._NpcGameObject = gameObject;
        _UiControl.GetComponent<uiController>().TalkUI();


        return true;
    }
}
