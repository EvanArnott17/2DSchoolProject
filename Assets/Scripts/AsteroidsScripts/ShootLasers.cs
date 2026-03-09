using Unity.VisualScripting;
using UnityEngine;

public class ShootLasers : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private Transform _spawnposition;
    [SerializeField] private float _chargeTime = 1f;

    private float _currentChargeTime = 0f;
    private bool _isCharging = false;
    private InputActions _inputs;

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
        if (_inputs.Player.Shoot.WasPressedThisFrame())
        {
            Debug.Log("Shooting");
            Instantiate(_laserPrefab, _spawnposition.position, _spawnposition.rotation);

        }

        //Super laser shot
        if (_inputs.Player.SuperLaser.WasPressedThisFrame())
        {
            _isCharging = true;
        }

        if(_isCharging && _inputs.Player.SuperLaser.IsPressed())
        {
            _currentChargeTime += Time.deltaTime;
            Debug.Log(_currentChargeTime);
        }

        if (_inputs.Player.SuperLaser.WasReleasedThisFrame())
        {
            _isCharging = false;
            if(_currentChargeTime > _chargeTime)
            {
                GameObject bigLaser = Instantiate(_laserPrefab, _spawnposition.position, _spawnposition.rotation);
                bigLaser.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            }
            _currentChargeTime = 0f;
        }
    }
}
