namespace GameplaySystems.Merchant
{
    public interface IMerchantInteract
    {
        public void OnItemPurchase(string itemID, int quantity, float itemPrice, float playerPrice);
        public void OnItemSold(string itemID, int quantity, float itemPrice, float playerPrice);
        public void OnWeekPay();
    }
}
