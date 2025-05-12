using TMPro;
using UnityEngine;

public class JournalEntry : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _QuestName;
    [SerializeField] private TextMeshProUGUI _QuestDesc;

    public void WriteEntry(QuestObject _Quest)
    {
        _QuestName.text = _Quest._QuestName;
        _QuestDesc.text = _Quest._QuestFlagDesc[_Quest._QuestFlag];
    }
    
}
