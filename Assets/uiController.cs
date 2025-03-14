using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
public class uiController : MonoBehaviour
{
    //game overlay
    private GameObject _MoneyUI;

    //pause screen
    private GameObject _PauseUI;

    private bool _HideUI;

    //player object to refer to public variables
    private GameObject _PlayerObj;

    void Start()
    {
        _PlayerObj = GameObject.Find("Player");

        _MoneyUI = GameObject.Find("MoneyUIParent");
        _MoneyUI.SetActive(true);

        _PauseUI = GameObject.Find("PauseUIParent");
        _PauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
            if (_PlayerObj.GetComponent<PlayerControlScript>()._Pause.triggered)
            {
            PauseGame();
            }

    }

    void PauseGame()
    {
        if (_PauseUI.activeSelf == true)
        {
            _MoneyUI.SetActive(true);
            _PauseUI.SetActive(false);
        }
        else
        {
            _MoneyUI.SetActive(false);
            _PauseUI.SetActive(true);
        }
    }
}
