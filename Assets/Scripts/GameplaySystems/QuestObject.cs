using UnityEngine;


[CreateAssetMenu(fileName = "QuestObj", menuName = "MerchantGameObject/Quest")]

public class QuestObject : ScriptableObject
{
    
    public string _QuestName;

    
    public string _QuestDescription;


    public int _QuestID;

    public int _QuestFlag;

    public string[] _QuestFlagDesc;
    
}
