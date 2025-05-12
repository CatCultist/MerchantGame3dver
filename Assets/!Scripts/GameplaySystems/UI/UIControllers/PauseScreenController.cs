using UnityEngine;
using TMPro;
public class PauseScreenController : MonoBehaviour
{
    [SerializeField] private GameObject _UiControl;
    [SerializeField] private Transform _JournalGrid;
    [SerializeField] private GameObject _JournalEntry;

    private GameObject _PlayerObj;
    private QuestManager _QuestManager;
    [SerializeField] private TextMeshProUGUI _PlayerBalance;

    void OnEnable()
    {
        _PlayerObj = GameObject.Find("Player");
        _PlayerObj.GetComponent<PlayerControls>()._Paused = true;
        _QuestManager = _PlayerObj.GetComponent<QuestManager>();
        foreach (var _Quest in _QuestManager._QuestList)
        {
            if(_Quest._QuestFlag != 0)
            {
                var _Entry = Instantiate(_JournalEntry);
                _Entry.transform.SetParent(_JournalGrid);
                _Entry.GetComponent<JournalEntry>().WriteEntry(_Quest);
            }
        }
        _PlayerBalance.text = "Balance: " + _PlayerObj.GetComponent<InventoryManager>().PlayerBalance.ToString() + "g";


    }

    private void OnDisable()
    {
        _PlayerObj.GetComponent<PlayerControls>()._Paused = false;
        foreach (Transform _Entry in _JournalGrid)
        {
            Destroy(_Entry.gameObject);
        }
    }


}
