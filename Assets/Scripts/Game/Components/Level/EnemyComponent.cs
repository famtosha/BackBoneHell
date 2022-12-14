using UnityEngine;
using UnityEngine.Events;

public class EnemyComponent : MonoBehaviour
{
    [field: SerializeField] public int soulCount { get; private set; }
    [SerializeField] private float _maxHealth;
    [SerializeField] private WeaponData _weaponData;
    [SerializeField] private WeaponDisplayComponent _weapon;

    public readonly UnityEvent<EnemyComponent> Death = new UnityEvent<EnemyComponent>();

    private PlayerComponent _player;

    public float health { get; private set; }

    private void Awake()
    {
        health = _maxHealth;
        _weapon.SetWeapon(new WeaponModel(_weaponData));
        _player = FindObjectOfType<PlayerComponent>();
    }

    private void Update()
    {
        LookToPlayer();
        Shoot();
    }

    private void Shoot()
    {
        _weapon.linkedWeapon.shootCD.UpdateTimer();
        if (_weapon.linkedWeapon.shootCD.isReady)
        {
            _weapon.linkedWeapon.Shoot(false);
            _weapon.linkedWeapon.shootCD.Reset();
        }
    }

    private void LookToPlayer()
    {
        var targetDirection = _player.transform.position - transform.position;
        var targetRotation = Quaternion.LookRotation(targetDirection, Vector3.forward) * Quaternion.Euler(90, -90, 0);
        _weapon.transform.rotation = Quaternion.Lerp(targetRotation, _weapon.transform.rotation, 0.9f);
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        health = Mathf.Max(health, 0);
        if (health <= 0)
        {
            Death?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
