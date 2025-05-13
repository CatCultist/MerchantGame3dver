using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public void Awake()
    {
        GameObject.Find("Player").transform.position = transform.position;
        GameObject.Find("MovePoint").transform.position = transform.position;
    }

}
