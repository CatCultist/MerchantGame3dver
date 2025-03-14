using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;
    public int wheatCount;
    public int fishCount;
    public float moneyCount;

    private void Awake()
    {
        Instance = this;
    }

    public void Take(int purchasedGood, float price)
    {
        switch (purchasedGood)
        {
            case 1:
                wheatCount++;
                moneyCount -= price;
                break;
            case 2:
                fishCount++;
                moneyCount -= price;
                break;
            default:
                Debug.Log("Invalid good, entered, something bwoke 3:");
                break;
        }
    }

    public void Give(int soldGood, float price)
    {
        switch (soldGood)
        {
            case 1:
                if (wheatCount > 0)
                {
                    wheatCount -= 1;
                    moneyCount += price;
                }
                break;
            case 2:
                if (fishCount > 0)
                {
                    fishCount -= 1;
                    moneyCount += price;
                }
                break;
            default:
                Debug.Log("Invalid good, removed, something bwoke 3:");
                break;
        }
    }
}
