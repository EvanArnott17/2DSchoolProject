using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestSpawner : MonoBehaviour
{
    private InputActions _inputs;

    [SerializeField] private GameObject[] _enemyPrefabs;

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
        if (_inputs.Player.SpawnTest.WasPressedThisFrame())
        {
            int enemyIndex = Random.Range(0, _enemyPrefabs.Length);

            Instantiate(_enemyPrefabs[enemyIndex], transform.position, Quaternion.identity);
        }
    }
}
