using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _moveDirection;

    [SerializeField] private float speed = 5f;

    [SerializeField] private Rigidbody2D body;

    [SerializeField] private float _jumpStrength = 5f;

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

    private void Update()
    {
        if (_playerInput.Player.Jump.WasPressedThisFrame())
        {
            Jump();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _moveDirection = _playerInput.Player.Move.ReadValue<Vector2>();

        body.linearVelocity = new Vector2(_moveDirection.x * speed, body.linearVelocity.y);

        ChangePlayerDirection(_moveDirection);

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

    private void Jump()
    {
        body.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
        Debug.Log("Jump Pressed");
    }


}
