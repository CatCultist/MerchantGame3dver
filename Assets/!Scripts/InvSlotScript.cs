using GameplaySystems.TradeGoods;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvSlotScript : MonoBehaviour
{
   
    public void SetGood(TradeGoods _Item, int _Quantity)
    {
        gameObject.GetComponent<Image>().sprite = _Item.tradeGoodSprite;
        transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = _Quantity.ToString();


    }
}
