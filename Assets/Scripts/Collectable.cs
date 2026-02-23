using UnityEngine;

public class Collectable : MonoBehaviour
{

    [SerializeField] private float _resetTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Rigidbody2D>() == true)
        {
            this.gameObject.SetActive(false);

            Invoke("ResetCollectable", _resetTime);
        }
    }

    private void ResetCollectable()
    {
        this.gameObject.SetActive(true);
    }
}
