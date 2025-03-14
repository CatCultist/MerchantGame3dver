using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance;
    public int wheatCount = 0;
    public int fishCount = 0;
    public float moneyCount = 5;

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
                wheatCount -= 1;
                moneyCount += price;
                break;
            case 2:
                fishCount -= 1;
                moneyCount += price;
                break;
            default:
                Debug.Log("Invalid good, removed, something bwoke 3:");
                break;
        }
    }
}
