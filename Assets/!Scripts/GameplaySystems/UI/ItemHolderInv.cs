using GameplaySystems.TradeGoods;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ItemHolderInv : MonoBehaviour, IPointerClickHandler
{
    public TradeGoods _TradeGood;
    [SerializeField] private Transform _OfferPosition;
    private MerchantUIController _MerchantUI;
    private Vector3 _DefaultPos;
    public bool _IsNpcItem;
    [HideInInspector] public bool _GoodSelected;
    private int _GoodQuantity;
    private TextMeshProUGUI _QuantityText;
    

    //[SerializeField] private GameObject _ItemWindow;
     void Awake()
    {

        _OfferPosition = GameObject.Find("OfferPanel").transform;
        _MerchantUI = GameObject.Find("MerchantUIParent").GetComponent<MerchantUIController>();
        _QuantityText = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        
    }

    public void SetGood(TradeGoods _Item, int _Quantity)
    {
        _GoodQuantity = _Quantity;
        _TradeGood = _Item;
        gameObject.GetComponent<Image>().sprite = _TradeGood.tradeGoodSprite;
        if (_IsNpcItem) { _QuantityText.text = ""; }
        else {_QuantityText.text = _GoodQuantity.ToString(); }
       

    }

    public void Refresh()
    {
        if (!_IsNpcItem && _GoodSelected)
        {
            if (_GoodQuantity > 0) { _GoodQuantity--; }
            
            _QuantityText.text = _GoodQuantity.ToString();
        }

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (_MerchantUI._TradeType == 0)
            {
                _DefaultPos = transform.position;
                _MerchantUI._SlotPos = _DefaultPos;
                Debug.Log(_DefaultPos);

                if (_IsNpcItem) { _MerchantUI._TradeType = 2; }
                else { _MerchantUI._TradeType = 1; }
                _MerchantUI._TradeGood = _TradeGood;
                
                transform.position = _OfferPosition.position + new Vector3(0, 10, 0);
                _GoodSelected = true;
                
            }
            else
            {
                if (_GoodSelected)
                {

                    transform.position = _DefaultPos;
                    _MerchantUI._TradeType = 0;
                    _GoodSelected = false;
                }
            }
            //_ItemWindow.SetActive(true);
            //_ItemWindow.transform.position = gameObject.transform.position;
            //_ItemWindow.GetComponent<TradeWindow>()._TradeGood = _TradeGood;


        }
    }
}
