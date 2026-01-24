using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _moveDirection;

    [SerializeField] private float speed = 5f;

    [SerializeField] private Rigidbody2D body;

    private SpriteRenderer playerSprite;

    private InputActions _playerInput;


    private void Awake()
    {
        _playerInput = new InputActions();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();

        _moveDirection = new Vector2(_moveDirection.x, _moveDirection.y);

        ChangePlayerDirection(_moveDirection);

        body.linearVelocity = _moveDirection * speed;
    }

    private void ChangePlayerDirection(Vector2 direction)
    {
        if (_moveDirection.x < 0)
        {

            playerSprite.flipX = true;
        }
        else if (_moveDirection.x > 0)
        {
            playerSprite.flipX = false;
        }
    }


}
