using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestObject[] _QuestList;

    public void SetQuestFlag(int _QuestNewFlag, int _QuestIDChange)
    {

        foreach (var _QuestIdCheck in _QuestList)
        {
            if (_QuestIdCheck._QuestID == _QuestIDChange) { _QuestIdCheck._QuestFlag = _QuestNewFlag; }
        }
    }
}
