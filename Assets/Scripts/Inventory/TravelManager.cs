using GameplaySystems.TradeGoods;
using UnityEngine;

public class TravelManager : MonoBehaviour
{
    public TravelManager Instance {get; private set;}

    [Range (0f, 1f)]
    public float travelSafetyModifier = 0.7f;

    private System.Random random = new System.Random();

    private void Awake()
    {
        if (Instance is not null)
        {
            Debug.LogError("Multiple Instances of TravelManager detected in scene, deleting the imposter");
            Destroy(gameObject);
        }
        Instance = this;
    }

    public void OnTravel()
    {
        var travelSafetyThreshold = 100 * travelSafetyModifier;

        var randomNumber = random.Next(1, 100);

        if (randomNumber > travelSafetyThreshold)
        {
            OnBanditAttack();
        }

        TimeManager.Instance.AdvanceDays();
    }

    private void OnBanditAttack()
    {
        InventoryManager.Instance.ItemDestroyed();
        InventoryManager.Instance.BalanceLost();
    }


}
