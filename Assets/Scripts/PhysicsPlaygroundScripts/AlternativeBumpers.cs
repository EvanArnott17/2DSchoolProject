using UnityEngine;

public class AlternativeBumpers : MonoBehaviour
{
    [SerializeField] private GameObject _alternativeBumper;

    [SerializeField] private Color _inactiveColor;

    [SerializeField] private Color _hitColor;

    [SerializeField] private float _bumpForce;

    private Color _originalColor;

    private SpriteRenderer _sprite;

    private CircleCollider2D _collider;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider2D>();
        _originalColor = _sprite.color;
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

                body.AddForce(-bounceDirection * _bumpForce, ForceMode2D.Impulse);
            }

            //Changing color of bumper on impact
            _sprite.color = _hitColor;
            ChangeActiveBumper();
        }
    }

    private void ChangeActiveBumper()
    {
        _sprite.color = _inactiveColor;
        _collider.enabled = false;

        //setting up the alternativeBumper
        CircleCollider2D alternateCollider = _alternativeBumper.GetComponent<CircleCollider2D>();
        SpriteRenderer alternateSprite = _alternativeBumper.GetComponent<SpriteRenderer>();

        alternateCollider.enabled = true;

        alternateSprite.color = _originalColor;
    }
}
