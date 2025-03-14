using UnityEngine;
using TMPro;
using System;

public class SalesManager : MonoBehaviour
{
    public InventoryController inventory;
    public Good good;
    [SerializeField] TextMeshProUGUI buyButton;

    private int _goodId;
    private float _price;

    private const float MerchantsCut = 0.90f;


    private void Sell()
    {
        _goodId = good.id;
        _price = good.basePrice * MerchantsCut;
        inventory.Give(_goodId, _price);
        Debug.Log("Sold wheat for: ");
        Debug.Log(_price);
    }

    public void ButtonPressed()
    {
        Sell();
    }
}
