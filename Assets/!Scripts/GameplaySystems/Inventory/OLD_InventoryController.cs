using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameplaySystems.TradeGoods;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;
    public TradeGoods[] _ItemList;
    public float _PlayerMoney;

    private void Awake()
    {
        Instance = this;
    }

    public void Take(string _GoodID, float _Price)
    {
        
    }

    public void Give(TradeGoods good)
    {

    }


}
