using UnityEngine;

public class ReactiveBumper : MonoBehaviour
{
    [SerializeField] private float _bumpForce = 10;

    [SerializeField] private Color _hitColor = Color.coral;

    private Color _originalColor;

    private SpriteRenderer _spriteColor;

    private void Awake()
    {
        _spriteColor = GetComponent<SpriteRenderer>();
        _originalColor = _spriteColor.color;
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D body = collision.gameObject.GetComponent<Rigidbody2D>();

            if (body != null)
            {
                //Getting the exact angle that the contact happens at
                //GetContact(0) is the way that unity gets the location of the first point of contact
                Vector2 bounceDirection = collision.GetContact(0).normal;

                body.AddForce(-bounceDirection *  _bumpForce, ForceMode2D.Impulse);
            }

            //Changing color of bumper on impact
            _spriteColor.color = _hitColor;
            Invoke("ResetColor", 0.2f);
        }
    }

    private void ResetColor()
    {
        _spriteColor.color = _originalColor;
    }
}
