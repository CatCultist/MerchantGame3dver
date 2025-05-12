using System.Collections.Generic;
using GameplaySystems.TradeGoods;
using Unity.VisualScripting;
using UnityEngine;

namespace GameplaySystems.Merchant
{
    public class MerchantStockController : MonoBehaviour
    {
        [SerializeField]
        private TradeGoods.TradeGoods[] startingGoods;
        public float MerchantBalance {get; private set;}

        public Dictionary<TradeGoods.TradeGoods, int> merchantGoodStock = new Dictionary<TradeGoods.TradeGoods, int>();
        
        public void Start()
        {
            if(startingGoods.Length == 0) return;
            foreach (TradeGoods.TradeGoods tradeGood in startingGoods)
            {
                merchantGoodStock.Add(tradeGood, tradeGood.tradeGoodBaseRestock);
            }
        }

        public bool OnRemoveStock(string itemID, int quantity, float price)
        {
            foreach (var goodStock in merchantGoodStock)
            {
                if (goodStock.Key.tradeGoodID == itemID)
                {
                    if (merchantGoodStock[goodStock.Key] < quantity)
                    {
                        Debug.Log("There is not enough of that good left in the merchants stock");
                        return false;
                    }
                    merchantGoodStock[goodStock.Key] -= quantity;
                    MerchantBalance += price;
                    return true;
                }
            }
            return false;
        }

        public void OnAddStock(string itemID, int quantity, float price)
        {
            foreach (var goodStock in merchantGoodStock)
            {
                if (goodStock.Key.tradeGoodID == itemID)
                {
                    merchantGoodStock[goodStock.Key] += quantity;
                    MerchantBalance -= price;
                    return;
                }
            }
        }

        public void OnAddWages(float wage)
        {
            MerchantBalance += wage;
        }
    }
}
