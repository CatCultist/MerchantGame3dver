using UnityEngine;
using TMPro;
using System;
using UnityEngine.Serialization;

public class SalesManager : MonoBehaviour
{
    public InventoryController inventory; // Inventory Controller gameObject
    public Good good; // Scriptable Object containing base data of the good, i.e. base price and ID
    
    [SerializeField] private TimeManager timeManager; // calls the timeManager gameObject

    private int _goodId; 
    private float _price; // initializing from other scripts

    [SerializeField] private float baseScarcityMultiplier; // for initial scarcity, e.g. fish in the mountains

    private float _dynamicScarcity;
    private float _villageStockValue;
    [SerializeField] private int villageStockLiteral;
    [SerializeField] private int villageStockBaseline; // use these four variables for setting dynamic scarcity for goods

    private const float MerchantsCut = 0.90f; // adjust this inside the script if undesirable


    private void Start()
    {
        _dynamicScarcity = 1f;
    }
    private float StockCalculation() 
    {
        // Finds a value between half and two times the base price of the good,
        // use this when displaying price changes in UI (outside of scope)
        _villageStockValue = Mathf.Clamp((villageStockLiteral % villageStockBaseline), 0.5f, 2);
        
        return(_villageStockValue);
    }
    
    private void Sell() // NEVER directly call this script for UI, it risks data leaks
    {
        _dynamicScarcity = StockCalculation();
        
        _goodId = good.id; // used for carrying data between scripts
        _price = good.basePrice * MerchantsCut * _dynamicScarcity; // price is calculated dynamically here
        inventory.Give(_goodId, _price); // sends data to Inventory, effects applied there
        Debug.Log("Sold wheat for: "); 
        Debug.Log(_price); // Debugging purposes, can be removed with proper UI implementation
    }

    public void ButtonPressed() // ALWAYS use this variable when calling from UI, helps protect data leaks
    {
        Sell();
        timeManager.AdvanceTime(); // Advances time by an hour
    }
}
