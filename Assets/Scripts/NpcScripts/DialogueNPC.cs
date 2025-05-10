using GameplaySystems.TradeGoods;
using UnityEngine;

[CreateAssetMenu(fileName = "New NpcObj", menuName = "MerchantGameObject/Create New NpcObj")]
public class NpcObj : ScriptableObject
{

    [Tooltip("ID number for the NPC")]
    public int _NpcID;

    [Tooltip("what talking with the NPC will do")]
    public int _DialogueType;

    [Tooltip("the npc's face sprite for dialogue")]
    public Sprite[] _NpcTalkSprite;

    [Tooltip("the dialogue the npc will speak")]
    public string[] _NpcDialogue;

    [Tooltip("the dialogue the npc will speak when reacting to trade deals. 0 is neutral; 1 is happy; 2 is angry; 3 means you forgot to input a price")]
    public string[] _ReactionDialogue;

    [Tooltip("the name of the NPC as displayed on the text box")]
    public string _NpcName;
}
