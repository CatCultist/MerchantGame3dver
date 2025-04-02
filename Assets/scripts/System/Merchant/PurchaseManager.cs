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

    [SerializeField] private TimeManager timeManager;
    
    private int _goodId;
    private float _price;
    
    [SerializeField] private float baseScarcityMultiplier;
    
    void Purchase()
    {
        _goodId = good.id;
        _price = good.basePrice * baseScarcityMultiplier;
        inventory.Take(_goodId, _price);
        Debug.Log("Purchased wheat for: ");
        Debug.Log(_price);
    }

    public void ButtonPressed()
    {
        timeManager.AdvanceTime();
        Purchase();
    }
}
