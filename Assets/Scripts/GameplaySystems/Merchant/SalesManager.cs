using UnityEngine;
using TMPro;
using System;
using GameplaySystems.TradeGoods;

/*
public class SalesManager : MonoBehaviour
{
    public InventoryController inventory;
    public TradeGoods good;
    [SerializeField] TextMeshProUGUI buyButton;
    
    [SerializeField] private TimeManager timeManager;

    private int _goodId;
    private float _price;

    [SerializeField] private float scarcityMultiplier;

    private const float MerchantsCut = 0.90f;
    

    private void Sell()
    {
        
        _goodId = good.id;
        _price = good.basePrice * MerchantsCut * scarcityMultiplier;
        inventory.Give(_goodId, _price);
        Debug.Log("Sold wheat for: ");
        Debug.Log(_price);
    }

    public void ButtonPressed()
    {
        Sell();
        timeManager.AdvanceTime();
    }
}
*/