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


    [SerializeField] private float scarcityMultiplier;


    private const float MerchantsCut = 0.90f;

    private void Awake()
    {
        inventory = GameObject.Find("Player").GetComponent<InventoryController>();
    }

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
    }
}
