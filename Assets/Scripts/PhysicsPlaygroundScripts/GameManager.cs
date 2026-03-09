using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Transform player;

    [SerializeField] private Transform _spawnpoint;

    public bool _isGameActive { get; private set; } = true;

    private void Awake()
    {
        instance = this;
    }

    public void OnPlayerDied()
    {
        _isGameActive = false;

        player.gameObject.SetActive(false);
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        Invoke("RespawnPlayer", 2f);
    }

    private void RespawnPlayer()
    {
        player.position = _spawnpoint .position;

        player.gameObject.SetActive(true);

        _isGameActive = true;
    }
}
