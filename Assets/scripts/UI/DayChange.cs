using System.Time;
using UnityEngine;

namespace UI
{
    public class DayChange : MonoBehaviour
    {
        // Temporary script for UI testing, please ignore
        [SerializeField] private TimeManager timeManager;
    
        public void Pressed()
        {
            timeManager.AdvanceDay();
        }
    }
}

