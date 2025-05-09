using GameplaySystems.TradeGoods;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemHolderInv : MonoBehaviour, IPointerClickHandler
{
    public TradeGoods _TradeGood;
    [SerializeField] private Transform _OfferPosition;
    private MerchantUIController _MerchantUI;
    private Vector3 _DefaultPos;
    //[SerializeField] private GameObject _ItemWindow;
     void Awake()
    {
        _DefaultPos = transform.position;
        
        _MerchantUI = GameObject.Find("MerchantUIParent").GetComponent<MerchantUIController>();
        gameObject.GetComponent<Image>().sprite = _TradeGood.tradeGoodSprite; 
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (_MerchantUI._TradeOwner == 0)
            {   
                _MerchantUI._TradeOwner = 1;
                _MerchantUI._TradeGood = _TradeGood;
                transform.position = _OfferPosition.position;
                
            }
            else
            {
                transform.position = _DefaultPos;
                _MerchantUI._TradeOwner = 0;
            }
            //_ItemWindow.SetActive(true);
            //_ItemWindow.transform.position = gameObject.transform.position;
            //_ItemWindow.GetComponent<TradeWindow>()._TradeGood = _TradeGood;


        }
    }
}
