using System;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class MoneyCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyCountText;
    [SerializeField] private InventoryController inventoryManager;

    private decimal _money;

    void Start()
    {
        inventoryManager = GameObject.Find("Player").GetComponent<InventoryController>();
        moneyCountText.text = "Calculating Money Count....";
    }
    void Update()
    {
        _money = (decimal)inventoryManager._PlayerMoney;
        _money = Decimal.Round(_money, 2);
        moneyCountText.text = "Money: " + _money.ToString("C");
    }
}
