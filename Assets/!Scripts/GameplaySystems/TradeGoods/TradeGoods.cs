using System;
using UnityEngine;

namespace GameplaySystems.TradeGoods
{
    [CreateAssetMenu(fileName = "TradeGoods", menuName = "MerchantGameObject/TradeGoods")]
    public class TradeGoods : ScriptableObject
    {
        [Header("Trade Good Identifiers")] 
        [Tooltip("Unique identifier for each trade good")]
        public string tradeGoodID;
        [Tooltip("Name of each trade good, displays in UI")]
        public string tradeGoodName;
        [Tooltip("Trade good description, displays in UI")] 
        public string tradeGoodDescription;
        [Tooltip("2D sprite for UI")]
        public Sprite tradeGoodSprite;
        
        [Header("Trade Good Merchant Values")]
        [Tooltip("Base price of goods, e.g gems will always be pricier than wheat")]
        public float tradeGoodBasePrice;
        [Tooltip("Base level restock each week before regional scarcity is considered")]
        public int tradeGoodBaseRestock;
        [Tooltip("How much of each good is consumed by the population at time intervals")]
        public float tradeGoodBaseConsumption;
        
        [Header("Trade Good Production Values")]
        [Tooltip("How much of each good is added to the towns stock each week")]
        public float tradeGoodBaseProduction;
        [Tooltip("How many weeks before the town will restock on the item")]
        public float tradeGoodBaseProductionRate;
        [Tooltip("On what days will these goods restock")]
        public string[] tradeGoodBaseDays;

    }
}
