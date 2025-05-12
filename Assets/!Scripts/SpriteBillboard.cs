using UnityEngine;

public class SpriteBillboard : MonoBehaviour
{
    public Camera _MainCamera;
    // Update is called once per frame
    private void Awake()
    {
        _MainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    void LateUpdate()
    {
        transform.forward = _MainCamera.transform.forward;
    }
}
