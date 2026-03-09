using UnityEngine;

public class DropTarget : MonoBehaviour
{
    private SpriteRenderer _sprite;

    private CapsuleCollider2D _collider;

    [SerializeField] private DropTargetManager _targetsDropped;

    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DisableDropTarget();
        }
    }

    private void Update()
    {
        if(_targetsDropped.targetCount == 3)
        {
            Invoke("RespawnDropTarget", 0.5f);
        }
    }

    private void DisableDropTarget()
    {
        _sprite.enabled = false;
        _collider.enabled = false;
        _targetsDropped.targetCount += 1;
        Debug.Log(_targetsDropped.targetCount);
    }

    private void RespawnDropTarget()
    {
        _sprite.enabled = true;
        _collider.enabled = true;
        _targetsDropped.targetCount = 0;
    }
}
