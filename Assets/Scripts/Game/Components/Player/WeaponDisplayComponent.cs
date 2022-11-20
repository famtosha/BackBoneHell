using UnityEngine;
using UnityEngine.Events;

public class WeaponDisplayComponent : MonoBehaviour
{
    public readonly UnityEvent WeaponChanged = new UnityEvent();

    [field: SerializeField] public SpriteRenderer sprite { get; private set; }
    [field: SerializeField] public Transform shootingOrigin { get; private set; }

    private WeaponModel _linkedWeapon;

    public WeaponModel linkedWeapon => _linkedWeapon;

    public void SetWeapon(WeaponModel weapon)
    {
        _linkedWeapon = weapon;
        _linkedWeapon.view = this;
        sprite.sprite = _linkedWeapon.displaySprite;
        WeaponChanged?.Invoke();
    }

    public void RemoveWeapon()
    {
        sprite.sprite = null;
        WeaponChanged?.Invoke();
    }
}
