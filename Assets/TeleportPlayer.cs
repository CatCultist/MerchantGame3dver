using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public void Awake()
    {
        GameObject.Find("Player").transform.position = transform.position;
    }

}
