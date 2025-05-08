using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameplaySystems.Merchant
{
    public class MerchantManager : MonoBehaviour
    {
        public static MerchantManager Instance {get; private set;}
        public float PlayerMoney {get; private set;}
        
        private List<IMerchantInteract> _merchantControllers;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("More than one MerchantManager Instance in the scene!");
                Destroy(gameObject);
            }
            Instance = this;
        }

        public void OnItemSold(int price, string merchantID, string itemID)
        {
            
        }

        public void OnItemPurchased(int price, string merchantID, string itemID)
        {
            
        }

        private List<IMerchantInteract> GetMerchantControllers() // gets every merchant controller script in the scene
        {
            IEnumerable<IMerchantInteract> merchantControllers = 
                FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.InstanceID).OfType<IMerchantInteract>();
            return _merchantControllers;
        }
    }
}
