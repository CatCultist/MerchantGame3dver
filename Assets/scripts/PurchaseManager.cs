using System;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.Serialization;

public class PurchaseManager : MonoBehaviour
{
    public InventoryController inventory;
    public Good good;
    [SerializeField] private TextMeshProUGUI buyButton;

    private int _goodId;
    private float _price;
    

    [SerializeField] private float scarcityMultiplier;

    private void Awake()
    {
        inventory = GameObject.Find("Player").GetComponent<InventoryController>();
    }
    void Purchase()
    {
        _goodId = good.id;
        _price = good.basePrice * scarcityMultiplier;
        if (inventory.moneyCount >= _price)
        {
            inventory.Take(_goodId, _price);
            Debug.Log("Purchased wheat for: ");
            Debug.Log(_price);
        }
        Debug.Log("You're broke bruh");
    }

    public void ButtonPressed()
    {
        Purchase();
    }
}
