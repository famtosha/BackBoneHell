using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Weapon")]
public class WeaponData : ScriptableObject
{
    [field: SerializeField] public string displayName { get; private set; }
    [field: SerializeField, ShowAssetPreview] public Sprite discplaySprite { get; private set; }
    [field: SerializeField] public float shootDelay { get; private set; }
    [field: SerializeReference, SubclassSelector] public ShootingStrategy shootingStrategy { get; private set; }
}
