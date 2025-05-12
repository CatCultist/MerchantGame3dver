using System;
using GameplaySystems.TradeGoods;
using UnityEngine;

namespace GameplaySystems.Merchant
{
    public class MerchantController : MonoBehaviour, IMerchantInteract
    {
        /*[Header("References")]
        */
        
        [Header("Merchant Settings")]
        [Tooltip("How likely the merchant is to accept barter deals - 0 being wont accept ever")] [Range(0f, 1f)]
        [SerializeField] private float merchantBargainingPower;
        [Tooltip("How much approval you gain/lose when you trade with the merchant")] [Range(0f, 1f)]
        [SerializeField] private float merchantHostility;
        [Tooltip("How much capital the merchant receives at the end of each in-game week")]
        [SerializeField] private float merchantSalary;
        [Tooltip("What sub-group of goods does this merchant specialise in")]
        [SerializeField] private MerchantSpecialty merchantSpecialty;
        
        public int MerchantScore { get; private set;}
        private float _merchantBalance;
        private float _dealSuccessChance;
        
        private string _transactionItemID;
        private int _transactionQuantity;
        private float _transactionChance;

        private float _itemPrice;
        private bool _shopOpen;
        private System.Random random = new System.Random();
        
        private MerchantStockController _merchantStock;

        private MerchantUIController _merchantUIController;
        private void Awake()
        {
            _merchantStock = GetComponent<MerchantStockController>();
            _merchantUIController = GameObject.Find("MerchantUIParent").GetComponent<MerchantUIController>();
        }
        
        public bool OnItemPurchase(string itemID, int quantity, float itemPrice, float playerPrice)
        {
            var desiredTrade = merchantSpecialty.desiredGoods;
            var undesiredTrade = merchantSpecialty.unDesiredGoods;

            var transactionChanceModifier = 1f;

            foreach (var desiredGood in desiredTrade)
            {
                if (desiredGood.tradeGoodID == itemID)
                {
                    transactionChanceModifier = .75f;
                    break;
                }
            }

            foreach (var undesiredGood in undesiredTrade)
            {
                if (undesiredGood.tradeGoodID == itemID)
                {
                    transactionChanceModifier = 1.5f;
                    break;
                }
            }

            var baseTransactionChance = 1f * transactionChanceModifier;
            var merchantScoreModifier = MerchantScore / 200;
            _transactionChance = Mathf.Clamp((baseTransactionChance * (playerPrice / itemPrice) * 100f) + merchantScoreModifier, 0, 1);

            var randomNumber = random.Next(1, 100);

            int merchantScoreChange;
            if (randomNumber > (_transactionChance * 100 + 1))
            {
                Debug.Log("Merchant rejects offer - lose opinion"); // For debugging, replace with UI functionality
                merchantScoreChange = Convert.ToInt32(_transactionChance - randomNumber);
                MerchantScore += Convert.ToInt32(merchantScoreChange * merchantHostility);
                Debug.Log(merchantScoreChange.ToString() + " merchant score");
                _merchantUIController.NpcResponse(2);
                return false;
            }

            Debug.Log("Merchant accepts offer - gain opinion");  // For debugging, replace with UI functionality
            merchantScoreChange = Convert.ToInt32(_transactionChance - randomNumber);
            MerchantScore += merchantScoreChange;
            _merchantUIController.NpcResponse(1);
            
            Debug.Log(merchantScoreChange.ToString() + " merchant score");

            _merchantStock.OnRemoveStock(itemID, quantity, playerPrice);
            return true;
        }

        public bool OnItemSold(string itemID, int quantity, float itemPrice, float playerPrice)
        {
            var doNotTrade = merchantSpecialty.impossibleGoods;
            var desiredTrade = merchantSpecialty.desiredGoods;
            var undesiredTrade = merchantSpecialty.unDesiredGoods;

            var transactionChanceModifier = 1f;

            foreach (var impossibleGood in doNotTrade)
            {
                if (impossibleGood.tradeGoodID == itemID)
                {
                    transactionChanceModifier = 0f;
                    break;
                }
            }

            foreach (var desiredGood in desiredTrade)
            {
                if (desiredGood.tradeGoodID == itemID)
                {
                    transactionChanceModifier = 1.5f;
                    break;
                }
            }

            foreach (var undesiredGood in undesiredTrade)
            {
                if (undesiredGood.tradeGoodID == itemID)
                {
                    transactionChanceModifier = .75f;
                    break;
                }
            }

            var baseTransactionChance = 1f * transactionChanceModifier;
            var merchantScoreModifier = MerchantScore / 200;
            _transactionChance = Mathf.Clamp((baseTransactionChance * (itemPrice / playerPrice) * 100f) + merchantScoreModifier, 0, 1);

            var randomNumber = random.Next(1, 100);

            int merchantScoreChange;
            if (randomNumber >= (_transactionChance * 100 + 1))
            {
                Debug.Log("Chance" + _transactionChance);
                Debug.Log("Offer" + playerPrice);

                Debug.Log("Merchant rejects offer - lose opinion"); // For debugging, replace with UI functionality
                merchantScoreChange = Convert.ToInt32(_transactionChance - randomNumber);
                MerchantScore += Convert.ToInt32(merchantScoreChange * merchantHostility);
                Debug.Log(merchantScoreChange.ToString() + " merchant score");
                _merchantUIController.NpcResponse(2);
                return false;
            }

            Debug.Log("Merchant accepts offer - gain opinion");  // For debugging, replace with UI functionality


            merchantScoreChange = Convert.ToInt32(_transactionChance - randomNumber);
            MerchantScore += merchantScoreChange;
            _merchantUIController.NpcResponse(1);
            
            Debug.Log(merchantScoreChange.ToString() + " merchant score");

            _merchantStock.OnAddStock(itemID, quantity, playerPrice);
            return true;
        }

        public void OnWeekPay()
        {
            if (_merchantStock.MerchantBalance > merchantSalary * 4) return;
            _merchantStock.OnAddWages(merchantSalary);
        }
    }
}
