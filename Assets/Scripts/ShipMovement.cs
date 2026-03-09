using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private InputActions _inputs;

    private Vector2 _moveInput;

    private void Awake()
    {
        _inputs = new InputActions();
    }

    private void OnEnable()
    {
        _inputs.Enable();
    }

    private void OnDisable()
    {
        _inputs.Disable();
    }

    private void Update()
    {
        /////Asteriods style controls
        _moveInput = _inputs.Player.Move.ReadValue<Vector2>();

        ////Spin ship keys
        transform.Rotate(0, 0, -_moveInput.x *  _rotationSpeed * Time.deltaTime);
        transform.Translate(new Vector2(0, _moveInput.y) *  _moveSpeed * Time.deltaTime, Space.Self);


        //Space Invaders Movement
        //_moveInput = _inputs.Player.Move.ReadValue<Vector2>();

        //transform.Translate(new Vector2(_moveInput.x, 0) * _moveSpeed * Time.deltaTime, Space.World);

        ////clamping movement to screen bounds
        //float clampX = Mathf.Clamp(transform.position.x, -11f, 11f);
        //transform.position = new Vector3(clampX, -4.5f, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            Debug.Log("Ship Entering Nebula");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            Debug.Log("Ship taking damage in nebula");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hazard"))
        {
            Debug.Log("Ship Exiting Hazard");
        }
    }
}
