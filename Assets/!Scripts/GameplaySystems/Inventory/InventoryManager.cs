using System;
using System.Collections.Generic;
using System.Linq;
using GameplaySystems.TradeGoods;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set;}

    public float PlayerBalance { get; private set;}
    public Dictionary<TradeGoods, int> playerGoodStock = new Dictionary<TradeGoods, int>();

    public TradeGoods _TestGood;
    public int _TestGoodCount;

    private System.Random random = new System.Random();

    private void Awake()
    {
        if (Instance is not null)
        {
            Debug.LogError("There is already an Instance of InventoryManager in the Scene, Destroying the Imposter");
            Destroy(gameObject);
        }
        Instance = this;
        PlayerBalance += 5;
        playerGoodStock.Add(_TestGood, _TestGoodCount);
        Debug.Log(PlayerBalance);

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
                    Debug.Log(tradeGood);
                    Debug.Log("The player does not have enough of that item to sell that quantity, try lowering the quantity.");
                    return;
                }
                var currentQuantity = playerGoodStock[stockedGood.Key];
                playerGoodStock[stockedGood.Key] = currentQuantity - quantity;
                PlayerBalance += price;
                
                Debug.Log("Balance" + PlayerBalance);
                return;
            }
        }

        Debug.LogError("The player has none of that item to sell, somethings gone wrong somewhere else");
    }

    public void ItemDestroyed()
    {
        var randomGood = playerGoodStock.ElementAt(random.Next(0, playerGoodStock.Count)).Key;

        var randomLostQauntity = random.Next(0, playerGoodStock[randomGood] / 2);

        playerGoodStock[randomGood] -= randomLostQauntity;
    }

    public void BalanceGained(float moneyValue)
    {

    }

    public void BalanceLost()
    {
        if (PlayerBalance > 100f)
        {
            var randomLostBalance = random.Next(1, Convert.ToInt32(PlayerBalance / 10f));

            PlayerBalance -= randomLostBalance;
        }
    }

}
