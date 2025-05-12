using UnityEngine;

public class DayChange : MonoBehaviour
{
    // Temporary script for UI testing, please ignore
    [SerializeField] private TimeManager timeManager;
    
    public void Pressed()
    {
        timeManager.AdvanceDays();
    }
}

