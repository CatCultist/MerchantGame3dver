using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerControls : MonoBehaviour
{
    //input system var
    public PlayerInputActions _PlayerControls;
    public InputAction _Move;
    public InputAction _Pause;
    public InputAction _Interact;
    public Animator animator;
    private Vector2 _MoveDirection;
    //----

    //movement var
    public float _MoveSpeed = 5f;
    public Transform _MovePoint;
    public LayerMask _StopMoveLayer;
    private Vector3 _MoveDistance;

    private Collider[] _HitWalls;



    //pause var
    public bool _Paused;
    //----

    //variable for restoring previous position when exiting sub-area
    public Vector3 _PreviousPosition;
    public string _PreviousScene;
    //----

    //to ensure only 1 player is ever created
    private static PlayerControls instance = null;
    //----

    private void Awake()
    {
        //avoid creating duplicates of player obj across scenes
        if (instance == null)
        {
            _PlayerControls = new PlayerInputActions();
            instance = this;
            _PlayerControls = new PlayerInputActions();
            DontDestroyOnLoad(gameObject);
            _PreviousScene = null;
        }
        else
        {
            Destroy(gameObject);
        }
        //----
    }



    private void OnEnable()
    {
        //input actions enable
        _Move = _PlayerControls.Player.Move;
        _Move.Enable();
        _Pause = _PlayerControls.Player.Pause;
        _Pause.Enable();
        _Interact = _PlayerControls.Player.Interact;
        _Interact.Enable();
        //----

    }

    void Start()
    {
        _MovePoint.parent = null;
        _HitWalls = new Collider[1];
    }

    void Update()
    {


            Debug.Log(Time.timeScale);
            //read player's direction
            if (!_Paused)
            {
                _MoveDirection = _Move.ReadValue<Vector2>();
            }

            animator.SetFloat("xmov", _MoveDirection.x);
            animator.SetFloat("ymov", _MoveDirection.y);

            //rotate _MoveDirection vector2 45 degrees
            //_MoveDirection = Rotate(_MoveDirection, -45);
            //---- 

            //move player along grid when input is detected
            transform.position = Vector3.MoveTowards(transform.position, _MovePoint.position, _MoveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _MovePoint.position) <= .5f)
            {
                MovePlayer();
            }
            //----



            //}

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
        //----

        //class for managing pause boolean
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
    }