using System;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int _currentHour;
    private int _currentDayNum; // when using UI reference the "currentDay" variable instead, 

    public string currentDay;


    private void Awake()
    {

    }

    private void Start()
    {
        // This would have the day start at 9:00 on sunday, 
        _currentHour = 9;
        _currentDayNum = 7;
    }

    public void AdvanceTime() // Call this variable when taking actions, no inputs required
    {
        if (_currentHour < 24f)
        {
            _currentHour++;
            Debug.Log(currentDay + ", " + Convert.ToString(_currentHour));
        }
        else
        {
            Debug.Log("Time is over");
        }
    }

    public void AdvanceDay() // Call this variable ONLY when the character sleeps
    {
        if (_currentDayNum == 7)
        {
            _currentDayNum = 0;
        }

        _currentHour = 9;
        _currentDayNum++;

        // setting a string variable based on the number for ui and display purposes
        // REFERENCE the "currentDay" variable when building UI
        switch (_currentDayNum)
        {
            case 1:
            {
                currentDay = "Monday";
                break;
            }
            case 2:
            {
                currentDay = "Tuesday";
                break;
            }
            case 3:
            {
                currentDay = "Wednesday";
                break;
            }
            case 4:
            {
                currentDay = "Thursday";
                break;
            }
            case 5:
            {
                currentDay = "Friday";
                break;
            }
            case 6:
            {
                currentDay = "Saturday";
                break;
            }
            case 7:
            {
                currentDay = "Sunday";
                break;
            }
            default:
            {
                Debug.Log("Incorrect Day Entered");
                break;
            }
                    
        }
    }


}
    
    
