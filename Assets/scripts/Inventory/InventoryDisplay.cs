using System.TradeGoods;
using TMPro;
using UnityEngine;

namespace Inventory
{
    public class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] private InventoryController inventoryManager;
        public Good good;
        [SerializeField] private TextMeshProUGUI textDisplay;

        private string _goodName;
        private int _goodCount;
        private int _goodId;

        private void Start()
        {
            _goodId = good.id;
            _goodName = good.name;
        }

        private void Update()
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
}
