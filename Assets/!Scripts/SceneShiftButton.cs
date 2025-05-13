using UnityEditor;

using UnityEngine;
using UnityEngine.SceneManagement;
using GameplaySystems;

public class SceneShiftButton : MonoBehaviour
{
    public string sceneName;

    public void OnTownClicked()
    {
        TravelManager.Instance.OnTravel(sceneName);
    }
}
