using System;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using UnityEngine.Serialization;
using GameplaySystems.TradeGoods;

public class PurchaseManager : MonoBehaviour
{
    public InventoryController inventory;
    public TradeGoods good;
    [SerializeField] private TextMeshProUGUI buyButton;

    [SerializeField] private TimeManager timeManager;
    
    private string _goodId;
    private float _price;
    

    [SerializeField] private float scarcityMultiplier;

    private void Awake()
    {
        inventory = GameObject.Find("Player").GetComponent<InventoryController>();
    }
    void Purchase()
    {
        _goodId = good.tradeGoodID;
        _price = good.tradeGoodBasePrice * scarcityMultiplier;
        if (inventory._PlayerMoney >= _price)
        {
            inventory.Take(_goodId, _price);
        }
        Debug.Log("You're broke bruh");
    }

    public void ButtonPressed()
    {
        //timeManager.AdvanceTime();
        Purchase();
    }

}
