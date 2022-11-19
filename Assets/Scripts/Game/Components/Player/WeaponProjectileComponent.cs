using UnityEngine;
using UnityEngine.Events;

public class WeaponProjectileComponent : MonoBehaviour
{
    public readonly UnityEvent<WeaponProjectileComponent, Collider2D> TriggerEntered = new UnityEvent<WeaponProjectileComponent, Collider2D>();

    public float speed { get; private set; }
    public float damage { get; private set; }

    public void Init(float speed, float damage)
    {
        this.speed = speed;
        this.damage = damage;
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }

    public void OnUpdate() { }

    public void ShowDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEntered?.Invoke(this, collision);
    }
}
