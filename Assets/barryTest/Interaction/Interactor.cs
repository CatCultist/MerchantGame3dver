using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    //variables
    [SerializeField] private Transform _InteractionPoint;
    [SerializeField] private float _InteractionRadius;
    [SerializeField] private LayerMask _InteractableMask;

    private PlayerControlScript _Control;
    private Collider[] _Colliders;

    private void Awake()
    {
        _Control = GetComponent<PlayerControlScript>();
    }


    // Update is called once per frame
    void Update()
    {
        _Colliders = Physics.OverlapSphere(_InteractionPoint.position, _InteractionRadius, _InteractableMask);

        if (!_Control._Paused) {
            if (_Colliders.Length > 0)
            {
                var interactable = _Colliders[0].GetComponent<I_Interactable>();

                if (interactable != null && _Control._Interact.triggered)
                {
                    interactable.Interact(this);
                }
            }
        }
    }


}
