using GameplaySystems.TradeGoods;
using UnityEngine;

[CreateAssetMenu(fileName = "New NpcObj", menuName = "MerchantGameObject/Create New NpcObj")]
public class NpcObj : ScriptableObject
{

    //ID number for the NPC
    public int _NpcID;

    //what talking with the NPC will do
    public int _DialogueType;

    //the npc's face sprite for dialogue
    public Sprite[] _NpcTalkSprite;

    //the dialogue the npc will speak
    public string[] _NpcDialogue;

    //the name of the NPC as displayed on the text box
    public string _NpcName;
}
