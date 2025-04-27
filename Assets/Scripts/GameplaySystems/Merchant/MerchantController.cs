using GameplaySystems.TradeGoods;
using UnityEngine;

namespace GameplaySystems.Merchant
{
    public class MerchantController : MonoBehaviour, IMerchantInteract
    {
        /*[Header("References")]
        */
        
        [Header("Merchant Settings")]
        [Tooltip("How likely the merchant is to accept barter deals")]
        [SerializeField] private float merchantBargainingPower;
        [Tooltip("How much approval you gain/lose when you trade with the merchant")]
        [SerializeField] private float merchantHostility;
        [Tooltip("How much capital the merchant receives at the end of each in-game week")]
        [SerializeField] private float merchantSalary;
        [Tooltip("What sub-group of goods does this merchant specialise in")]
        [SerializeField] private MerchantSpecialty merchantSpecialty;
        
        private int _merchantScore;
        private float _merchantBalance;
        private float _dealSuccessChance;
        
        private string _transactionItemID;
        private int _transactionQuantity;
        private float _transactionChance;
        
        
        private float _itemPrice;
        private bool _shopOpen;
        
        private MerchantStockController _merchantStock;

        private void Awake()
        {
            _merchantStock = GetComponent<MerchantStockController>();
        }
        
        public void OnItemPurchase(string itemID, int quantity, float itemPrice)
        {
            
            
            _merchantStock.OnRemoveStock(itemID, quantity, itemPrice);
        }

        public void OnItemSold(string itemID, int quantity, float itemPrice)
        {
            TradeGoods.TradeGoods[] doNotTrade = merchantSpecialty.impossibleGoods;

            foreach (TradeGoods.TradeGoods impossibleGood in doNotTrade)
            {
                if (impossibleGood.tradeGoodID == itemID)
                {
                    _transactionChance = 0f;
                    break;
                }
            }
            
            _merchantStock.OnAddStock(itemID, quantity, itemPrice);
        }
    }
}
