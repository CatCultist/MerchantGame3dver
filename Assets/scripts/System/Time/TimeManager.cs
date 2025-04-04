using Unity.VisualScripting;
using UnityEngine;

namespace System.Time
{
    public class TimeManager : MonoBehaviour
    {
        private int _currentHour;
        private int _currentDayNum; // when using UI reference the "currentDay" variable instead, 

        public string currentDay;
    
        private void Start()
        {
            // This would have the day start at 9:00 on sunday, 
            _currentHour = 8;
            _currentDayNum = 7;
        }

        public void AdvanceTime() // Call this variable when taking actions, no inputs required
        {
            if (_currentHour < 24f)
            {
                _currentHour++;
                Debug.Log(currentDay + ", " + Convert.ToString(_currentHour)); // Can be removed when no longer needed for debug
            }
            else
            {
                Debug.Log("Time is over"); // Debugging purposes, will be replaced with functionality later
            }

            switch (_currentHour) // For UI functionality, simply activate and deactivate UI frames here
            {
                case 12:
                {
                    Debug.Log("Afternoon"); // Replace debug with UI functionality in future
                    break;
                }

                case 16:
                {
                    Debug.Log("Evening"); // same as above
                    break;
                }

                case 20:
                {
                    Debug.Log("Night"); // same as above
                    break;
                }

                case 24:
                {
                    Debug.Log("Midnight"); // again see above
                    break;
                }
            }
            
            
        }

        public void AdvanceDay() // Call this variable ONLY when the character sleeps
        {
            if (_currentDayNum == 7) // must be placed before the addition to ensure monday isnt skipped
            {
                _currentDayNum = 0;
            }

            _currentHour = 8; // default morning time, could be changed to whatever suits
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
}
    
    
