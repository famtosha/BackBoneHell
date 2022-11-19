using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public float health { get; private set; }

    private void Awake()
    {
        health = _maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
