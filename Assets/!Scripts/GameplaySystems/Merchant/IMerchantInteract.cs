namespace GameplaySystems.Merchant
{
    public interface IMerchantInteract
    {
        public bool OnItemPurchase(string itemID, int quantity, float itemPrice, float playerPrice);
        public bool OnItemSold(string itemID, int quantity, float itemPrice, float playerPrice);
        public void OnWeekPay();
    }
}
