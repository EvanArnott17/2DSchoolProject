using UnityEngine;

public class Coin : MonoBehaviour
{
    private SpriteRenderer _sprite;

    private CapsuleCollider2D _collider;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HideCoin();

            Invoke("ResetCoin", 3f);
        }
    }

    private void HideCoin()
    {
        _sprite.enabled = false;
        _collider.enabled = false;
    }

    private void ResetCoin()
    {
        _sprite.enabled = true;
        _collider.enabled = true;
    }
}
