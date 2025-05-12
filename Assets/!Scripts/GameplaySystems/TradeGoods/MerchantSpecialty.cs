using UnityEngine;

namespace GameplaySystems.TradeGoods
{
    [CreateAssetMenu(fileName = "MerchantSpecialty", menuName = "MerchantGameObject/MerchantSpecialty")]
    public class MerchantSpecialty : ScriptableObject
    {
        [Header("Desired Goods")] 
        [Tooltip("These goods are often heavily in demand, and will have significant mark ups")]
        public TradeGoods[] desiredGoods;
        
        [Header("Undesirable Goods")] 
        [Tooltip("These goods are readily available for the merchant already, and will usually be marked down")]
        public TradeGoods[] unDesiredGoods;
        
        [Header("Staple Goods")]
        [Tooltip("These goods dont deviate far from base price, as they are always required")]
        public TradeGoods[] stapleGoods;

        [Header("Goods for Sale")]
        [Tooltip("These are the goods which this merchant will sell each day at the market")]
        public TradeGoods[] soldGoods;
        
        [Header("Goods that will not Sell")]
        [Tooltip("These are the goods that the merchant wont buy, as they have no use for them")]
        public TradeGoods[] impossibleGoods;
    }
}
