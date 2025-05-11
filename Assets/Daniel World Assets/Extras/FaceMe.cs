using UnityEngine;

public class FaceMe : MonoBehaviour
{
    public GameObject mLookAt;
    private Transform localTrans;

    void Start()
    {
        localTrans = GetComponent<Transform>();
        mLookAt = GameObject.Find("Main Camera");
    }    

    void Update()
    {
        if(mLookAt)
        {
            transform.forward = mLookAt.transform.forward;
        }
    }

}
