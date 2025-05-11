using System.Collections.Generic;
using GameplaySystems.TradeGoods;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set;}

    public float PlayerBalance { get; private set;}
    private Dictionary<TradeGoods, int> playerGoodStock = new Dictionary<TradeGoods, int>();

    private void OnAwake()
    {
        if (Instance is not null)
        {
            Debug.LogError("There is already an Instance of InventoryManager in the Scene, Destroying the Imposter");
            Destroy(gameObject);
        }
        Instance = this;
    }

    public void ItemPurchased(TradeGoods tradeGood, int quantity, float price)
    {
        foreach(var stockedGood in playerGoodStock)
        {
            if (stockedGood.Key == tradeGood)
            {
                var currentQuantity = playerGoodStock[stockedGood.Key];
                playerGoodStock[stockedGood.Key] = currentQuantity + quantity;
                PlayerBalance -= price;
                return;
            }
        }

        playerGoodStock.Add(tradeGood, quantity);
        PlayerBalance -= price;
    }

    public void ItemSold(TradeGoods tradeGood, int quantity, float price)
    {
        foreach(var stockedGood in playerGoodStock)
        {
            if (stockedGood.Key == tradeGood)
            {
                if (playerGoodStock[stockedGood.Key] < quantity)
                {
                    Debug.Log("The player does not have enough of that item to sell that quantity, try lowering the quantity.");
                    return;
                }
                var currentQuantity = playerGoodStock[stockedGood.Key];
                playerGoodStock[stockedGood.Key] = currentQuantity - quantity;
                PlayerBalance += price;
                return;
            }
        }

        Debug.LogError("The player has none of that item to sell, somethings gone wrong somewhere else");
    }

    public void ItemDestroyed(TradeGoods tradeGood, int quantity)
    {

    }

    public void BalanceGained(float moneyValue)
    {

    }

    public void BalanceLost(float moneyValue)
    {
        
    }

}
