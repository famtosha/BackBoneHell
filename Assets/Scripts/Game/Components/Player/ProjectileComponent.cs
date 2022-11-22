using UnityEngine;
using UnityEngine.Events;

public class ProjectileComponent : MonoBehaviour
{
    public readonly UnityEvent<ProjectileComponent, Collider2D> TriggerEntered = new UnityEvent<ProjectileComponent, Collider2D>();

    public float speed { get; private set; }
    public float damage { get; private set; }
    public bool players { get; private set; }

    public void Init(float speed, float damage, bool players)
    {
        this.speed = speed;
        this.damage = damage;
        this.players = players;
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
