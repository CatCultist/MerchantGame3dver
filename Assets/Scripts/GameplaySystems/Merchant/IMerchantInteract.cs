namespace GameplaySystems.Merchant
{
    public interface IMerchantInteract
    {
<<<<<<< HEAD
        public void OnItemPurchase(string itemID, int quantity, float itemPrice, float playerPrice);
        public void OnItemSold(string itemID, int quantity, float itemPrice, float playerPrice);
=======
        public void OnItemPurchase(TradeGoods.TradeGoods tradeGood, string itemID, int quantity, float itemPrice, float playerPrice);
        public void OnItemSold(TradeGoods.TradeGoods tradeGood, string itemID, int quantity, float itemPrice, float playerPrice);
>>>>>>> ciaran
        public void OnWeekPay();
    }
}
