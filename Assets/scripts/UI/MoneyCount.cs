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
        moneyCountText.text = "Calculating Money Count....";
    }
    void Update()
    {
        _money = (decimal)inventoryManager.moneyCount;
        _money = Decimal.Round(_money, 2);
        moneyCountText.text = "Money: " + _money.ToString("C");
    }
}
