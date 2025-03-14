using UnityEngine;

[CreateAssetMenu(fileName = "New Good", menuName = "Item/Create New Good")]
public class Good : ScriptableObject
{
    public int id;
    public string goodName;
    public float basePrice;
    public Sprite icon;
}
