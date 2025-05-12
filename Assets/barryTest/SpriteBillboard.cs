using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    public Camera _MainCamera;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.forward = _MainCamera.transform.forward;
    }
}
