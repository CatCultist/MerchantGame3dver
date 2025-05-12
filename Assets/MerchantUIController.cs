using UnityEngine;
using TMPro;
using GameplaySystems.Merchant;
public class MerchantUIController : MonoBehaviour
{
    [SerializeField] private GameObject _PlayerMoney;
    [SerializeField] private TextMeshProUGUI _PlayerMoneyField;
    [SerializeField] private GameObject _ShopPanels;
    [SerializeField] private GameObject _NpcUI;
    [SerializeField] private GameObject _ButtonManager;

    private InventoryController _PlayerInv;
    public MerchantController _MerchantInv;
    
    private void Awake()
    {
       _PlayerInv = GameObject.Find("Player").GetComponent<InventoryController>();      
    }

    public void StartShopping()
    {
      _PlayerMoneyField.text = _PlayerInv.moneyCount.ToString();

      _PlayerMoney.SetActive(true);
      _ShopPanels.SetActive(true);
      _NpcUI.SetActive(true);
      _ButtonManager.SetActive(true);
    }
}
