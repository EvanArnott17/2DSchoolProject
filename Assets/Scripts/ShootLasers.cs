using Unity.VisualScripting;
using UnityEngine;

public class ShootLasers : MonoBehaviour
{
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private Transform _spawnposition;

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
            GameObject laser = Instantiate(_laserPrefab);
            //laser.transform = _spawnposition;

        }
    }
}
