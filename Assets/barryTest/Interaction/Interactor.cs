using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    //variables
    [SerializeField] private Transform _InteractionPoint;
    [SerializeField] private float _InteractionRadius;
    [SerializeField] private LayerMask _InteractableMask;

    private Collider[] _Colliders;




    // Update is called once per frame
    void Update()
    {
        _Colliders = Physics.OverlapSphere(_InteractionPoint.position, _InteractionRadius, _InteractableMask);


        if (_Colliders.Length > 0)
        {
            var interactable = _Colliders[0].GetComponent<I_Interactable>();

            if (interactable != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                interactable.Interact(this);
            }
        }
    }


}
