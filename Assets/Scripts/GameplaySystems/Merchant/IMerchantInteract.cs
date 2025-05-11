namespace GameplaySystems.Merchant
{
    public interface IMerchantInteract
    {
        public void OnItemPurchase(TradeGoods.TradeGoods tradeGood, string itemID, int quantity, float itemPrice, float playerPrice);
        public void OnItemSold(TradeGoods.TradeGoods tradeGood, string itemID, int quantity, float itemPrice, float playerPrice);
        public void OnWeekPay();
    }
}
