using UnityEngine;

public class JumpPad : MonoBehaviour
{

    [SerializeField] private float _bounceHeight = 10f;

    private SpriteRenderer _padColor;

    private Color _ogColor;

    private void Awake()
    {
        _padColor = GetComponent<SpriteRenderer>();
        _ogColor = _padColor.color;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //adding a bounce if something with the player tag moves over the bounce pad
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if(rb != null)
            {
                rb.AddForce(Vector2.up *  _bounceHeight, ForceMode2D.Impulse);
            }

            //Change bounce pad color
            _padColor.color = Color.aquamarine;

            Invoke("ResetColor", 0.5f);
        }
    }

    private void ResetColor()
    {
        _padColor.color = _ogColor;
    }
}
