using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpringLauncher : MonoBehaviour
{
    private InputActions _input;

    [SerializeField] private float _maxForce = 20f;
    [SerializeField] private float _chargeSpeed = 15f;
    [SerializeField] private float _squishAmount = 1f;

    private float _currentCharge = 0f;

    private bool _isOnTop = false;
    private Rigidbody2D _body;
    private Vector3 _initialScale;

    //Awake will trigger every time the script is enabled so if it is enabled and disabled
    //it will trigger again whearas start will only trigger once on the first frame the scene is loaded
    private void Awake()
    {
        _input = new InputActions();
        _body = GetComponent<Rigidbody2D>();
        _initialScale = transform.localScale; // gets the current value of the transform
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isOnTop = true;
            _body = collision.GetComponent<Rigidbody2D>();
            Debug.Log(_isOnTop);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isOnTop = false;
            _body = null;
            _currentCharge = 0f;
            transform.localScale = _initialScale; //resetting the size of the spring
        }
    }

    private void Update()
    {
        //Game manager gating which will be implemented later
        //if(GameManager.Instance.IsGameActive == false) return;

        if (!_isOnTop)
        {
            return;
        }

        ///Charging the squish
        if (_input.Player.Interact.IsPressed())
        {
            _currentCharge += _chargeSpeed * Time.deltaTime;
            //Mathf.Clamp clamps the value(first value, between a min and a max amount the second and third values
            _currentCharge = Mathf.Clamp(_currentCharge, 0, _maxForce);

            float chargePercentage = _currentCharge / _maxForce;

            //Actually squishing the sprite
            //Lerp is a linear value between two values and it makes for smoother movement
            float newY = Mathf.Lerp(_initialScale.y, _squishAmount, chargePercentage);

            transform.localScale = new Vector3(_initialScale.x, newY, _initialScale.z);
        }

        if (_input.Player.Interact.WasReleasedThisFrame())
        {
            LaunchPlayer();
        }
    }

    private void LaunchPlayer()
    {
        if(_body != null)
        {
            ///Launches the player up and snaps the spring back to initial scale
            _body.AddForce(Vector2.up * _currentCharge, ForceMode2D.Impulse);
            transform.localScale = _initialScale;
            _currentCharge = 0f;
        }
    }


}
