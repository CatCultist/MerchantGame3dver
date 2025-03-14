using UnityEngine;

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
        if (_Inventory.moneyCount >= _Cost)
        {
            _Inventory.moneyCount -= _Cost;
            _Inventory.wheatCount++;
            Debug.Log(_Inventory.wheatCount);
        }

        return true;
    }
}
