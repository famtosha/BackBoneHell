using UnityEngine;

public class PlayerWeaponsComponent : MonoBehaviour
{
    [field: SerializeField] public WeaponDisplayComponent a { get; private set; }
    [field: SerializeField] public WeaponDisplayComponent b { get; private set; }

    public WeaponDisplayComponent activeWeapon => a;
}
