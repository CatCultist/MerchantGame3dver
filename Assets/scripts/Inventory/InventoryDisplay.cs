/*
using UnityEngine;
using TMPro;
using GameplaySystems.TradeGoods;

public class InventoryDisplay : MonoBehaviour
{
    private InventoryController inventoryManager;
    public TradeGoods good;
    [SerializeField] private TextMeshProUGUI textDisplay;

    private string _goodName;
    private int _goodCount;
    private int _goodId;

    void Start()
    {
        inventoryManager = GameObject.Find("Player").GetComponent<InventoryController>();

        _goodId = good.tradeGoodID;
        _goodName = good.name;
    }

    void Update()
    {
        switch (_goodId)
        {
            case 1:
                _goodCount = inventoryManager.wheatCount;
                break;
            case 2:
                _goodCount = inventoryManager.fishCount;
                break;
            default:
                Debug.Log("Invalid good, removed, something bwoke 3:");
                break;
        }
        
        textDisplay.text = _goodName + ": " + _goodCount;
    }

}
*/