using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private int _enemyRows = 3;
    [SerializeField] private int _enemyColumns = 5;
    [SerializeField] private float _spacing = 1.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemies()
    {
        Quaternion faceDown = Quaternion.Euler(0, 0, 180);
        for(int r = 0; r < _enemyRows; r++)
        {
            for(int c = 0; c < _enemyColumns; c++)
            {
                Vector2 spawnPosition = new Vector2(transform.position.x +(c * _spacing),
                    transform.position.y - (r * _spacing));

                GameObject newShip = Instantiate(_enemyPrefab, spawnPosition, faceDown);

                //making the new ship a child of the manager
                newShip.transform.SetParent(this.transform);
            }
        }
    }
}
