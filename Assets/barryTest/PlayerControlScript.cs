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
    public Animator animator;
    private Vector2 _MoveDirection;
    private bool _MovingPlayer;

    //movement var
    public float _MoveSpeed = 5f;
    public Transform _MovePoint;
    public LayerMask _StopMoveLayer;
    private Vector3 _MoveDistance;
    private Collider[] _HitWalls;

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
        _HitWalls = new Collider[1];
    }

    void Update()
    {

        //_MoveDirection = _Move.ReadValue<Vector2>();
        Debug.Log("Y:" + _MoveDirection.y);
        Debug.Log("X:" + _MoveDirection.x);

        animator.SetFloat("xmov", _MoveDirection.x);
        animator.SetFloat("ymov", _MoveDirection.y);

        _MoveDirection = _Move.ReadValue<Vector2>();


        //waits a moment before moving
        _Move.performed +=
            context =>
            {
                _MovingPlayer = true;

            };

        //moves player along the grid
       // if (_MovingPlayer)
        //{
            if (Vector3.Distance(transform.position, _MovePoint.position) <= .05f)
            {
                MovePlayer();
            }


        //}
        transform.position = Vector3.MoveTowards(transform.position, _MovePoint.position, _MoveSpeed * Time.deltaTime);


        //halt movement when button is released
        if (_Move.WasReleasedThisFrame())
        {
            _MovingPlayer = false;
        }

        if (_Pause.triggered)
        {
            PauseGame();
        }


    }

    //movement function
    private void MovePlayer()
    {
        //rotate _MoveDirection vector2 45 degrees
        _MoveDirection = Rotate(_MoveDirection, -45);
        //--    


        //diagonal movement
        if (Mathf.Abs(_MoveDirection.x) > 0f && Mathf.Abs(_MoveDirection.y) > 0f)
        {
            _MoveDistance = new Vector3(Mathf.Round(_MoveDirection.x), 0f, Mathf.Round(_MoveDirection.y));
            int _WallsCollider = Physics.OverlapSphereNonAlloc(_MovePoint.position + _MoveDistance, 0.2f, _HitWalls, _StopMoveLayer);
            if (_WallsCollider == 0)
            {
                _MovePoint.position += _MoveDistance;
            }
        }
        //--

        //straight movement
        if (Mathf.Abs(_MoveDirection.x) == 1f)
        {
            _MoveDistance = new Vector3(Mathf.Round(_MoveDirection.x), 0f, 0f);
            int _WallsCollider = Physics.OverlapSphereNonAlloc(_MovePoint.position + _MoveDistance, 0.2f, _HitWalls, _StopMoveLayer);
            if (_WallsCollider == 0)
            {
                _MovePoint.position += _MoveDistance;
            }
        }

        if (Mathf.Abs(_MoveDirection.y) == 1f)
        {
            _MoveDistance = new Vector3(0f, 0f, Mathf.Round(_MoveDirection.y));
            int _WallsCollider = Physics.OverlapSphereNonAlloc(_MovePoint.position + _MoveDistance, 0.2f, _HitWalls, _StopMoveLayer);
            if (_WallsCollider == 0)
            {
                _MovePoint.position += _MoveDistance;
            }
        }
    }

    //--


    //adjust vector angle function
    private Vector2 Rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }
    //--

    //pause function
    public void PauseGame()
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
    //--
}
