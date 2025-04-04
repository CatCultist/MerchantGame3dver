
using System.Time;
using System.TradeGoods;
using UnityEngine;

namespace System.Merchant
{
    public class PurchaseManager : MonoBehaviour
    {
        public InventoryController inventory; // Inventory Controller gameObject
        public Good good; // Scriptable Object containing base data of the good, i.e. base price and ID

        [SerializeField] private TimeManager timeManager; // calls the timeManager gameObject
    
        private int _goodId;
        private float _price; // initializing from other scripts
    
        [SerializeField] private float baseScarcityMultiplier; // for initial scarcity, e.g. fish in the mountains

        [SerializeField] private int initialStock; // set initial stock value, the 'default' value after a reset
        
        private float _dynamicScarcity;
        private float _villageStockValue;
        private int _villageStockLiteral;
        [SerializeField] private int villageStockBaseline; // use these four variables for setting dynamic scarcity for goods
    
        private void Start()
        {
            _dynamicScarcity = 1f;
        }
        
        private float StockCalculation() 
        {
            // Finds a value between half and two times the base price of the good,
            // use this when displaying price changes in UI (most likely outside of scope)
            _villageStockValue = Mathf.Clamp(_villageStockLiteral % villageStockBaseline, 0.5f, 2);
        
            return(_villageStockValue);
        }

        private void RemoveStock() // Function for removing stock
        {
            _villageStockLiteral--;
            
            /*
            for Barry:
            some suggestions for dynamic UI implementation could be as follows
            - avoid looping the process of invoking the function, as this is expensive on memory
            - pass in a value from the UI, Text mesh pro input fields should work fine,
            be careful however as to take in/ convert the value to an integer
            - floats should not be taken in as they will be more expensive when calculating
            and serve no necessary purpose

            something along the lines of;

            (input field class)
            SET CONTENT TO - Integer Number

            string inputText;
            int inputParsedAsInt;

            private int GrabFromInput(string input)
            {
               if (input == string.Empty)
               {
                   return;
               }

           inputParsedAsInt = int.Parse(input);

           return(inputParsedAsInt)
            }

            This class
            InputFieldClass purchaseQuantityManager;
            int quantity;

            purchaseQuantityManager.GrabFromInput() = quantity;
           */
        }
    
        private void Purchase() // NEVER directly call this script for UI, it risks data leaks
        {
            _dynamicScarcity = StockCalculation();
        
            _goodId = good.id; // used for carrying data between scripts
            _price = good.basePrice * _dynamicScarcity * baseScarcityMultiplier; // price is calculated dynamically here
            inventory.Give(_goodId, _price); // sends data to Inventory, effects applied there
            
            RemoveStock();
            
            Debug.Log("Sold wheat for: "); 
            Debug.Log(_price); // Debugging purposes, can be removed with proper UI implementation
        }

        public void ButtonPressed() // ALWAYS use this function when calling from UI, helps protect data leaks
        {
            Purchase();
            timeManager.AdvanceTime(); // Advances time by an hour
        }
    }
}
