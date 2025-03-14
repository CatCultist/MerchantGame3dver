using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerControlScript : MonoBehaviour
{
    //input system var
    public PlayerInputActions _PlayerControls;
    public InputAction _Move;
    public InputAction _Pause;
    private Vector2 _MoveDirection;

    //movement var
    public float _MoveSpeed = 5f;
    public Transform _MovePoint;
    public LayerMask _StopMoveLayer;
    private Vector3 _MoveDistance;

    //pause var
    private bool _Paused;

    private void Awake()
    {
        _PlayerControls = new PlayerInputActions();
    }

    private void OnEnable()
    {
        _Move = _PlayerControls.Player.Move;
        _Move.Enable();
        _Pause = _PlayerControls.Player.Pause;
        _Pause.Enable();
    }

    void Start()
    {
        _MovePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        _MoveDirection = _Move.ReadValue<Vector2>();
        Debug.Log("Y:" + _MoveDirection.y);
        Debug.Log("X:" + _MoveDirection.x);


        transform.position = Vector3.MoveTowards(transform.position, _MovePoint.position, _MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _MovePoint.position) <= .05f)
            {
                if (Mathf.Abs(_MoveDirection.x) > 0f && Mathf.Abs(_MoveDirection.y) > 0f)
                {
                    _MoveDistance = new Vector3(Mathf.Round(_MoveDirection.x), 0f, Mathf.Round(_MoveDirection.y));
                    Collider[] _WallsCollider = Physics.OverlapSphere(_MovePoint.position + _MoveDistance, 0.2f, _StopMoveLayer);
                    if (_WallsCollider.Length == 0)
                    {
                        _MovePoint.position += _MoveDistance;
                    }
                }

                if (Mathf.Abs(_MoveDirection.x) == 1f)
                {
                    _MoveDistance = new Vector3(_MoveDirection.x, 0f, 0f);
                    Collider[] _WallsCollider = Physics.OverlapSphere(_MovePoint.position + _MoveDistance, 0.2f, _StopMoveLayer);
                    if (_WallsCollider.Length == 0)
                    {
                        _MovePoint.position += _MoveDistance;
                    }
                }

                if (Mathf.Abs(_MoveDirection.y) == 1f)
                {
                    _MoveDistance = new Vector3(0f, 0f, _MoveDirection.y);
                    Collider[] _WallsCollider = Physics.OverlapSphere(_MovePoint.position + _MoveDistance, 0.2f, _StopMoveLayer);
                    if (_WallsCollider.Length == 0)
                    {
                        _MovePoint.position += _MoveDistance;
                    }
                }
            }
        

        
        if (_Pause.triggered)
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (!_Paused)
        {
            _Paused = true;
            Time.timeScale = 0f;
        }
        else if (_Paused)
        {
            _Paused = false;
            Time.timeScale = 1f;
        }

    }
}
