using UnityEngine;

public enum DayPeriods
{
    Morning, Afternoon, Evening, Night
}

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance {get; private set;}


    public DayPeriods CurrentPeriod {get; private set;}

    private int currentDay, currentHour;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("TimeManager already in scene");
            Destroy(gameObject);
        }
        Instance = this;

        currentDay = 7;
        currentHour = 8;
        CurrentPeriod = DayPeriods.Morning;
    }

    public void AdvanceHours()
    {
        if(currentHour >= 24) return;

        currentHour++;

        CurrentPeriod =
            currentHour < 12 ? DayPeriods.Morning :
            currentHour < 16 ? DayPeriods.Afternoon :
            currentHour < 20 ? DayPeriods.Evening : 
            DayPeriods.Night;    
    }

    public void AdvanceDays()
    {
        if (currentDay == 7) {AdvanceWeek(); return;}

        currentDay++;
        currentHour = 8;
    }

    private void AdvanceWeek()
    {
        currentDay = 1;
        currentHour = 8;
    }

}