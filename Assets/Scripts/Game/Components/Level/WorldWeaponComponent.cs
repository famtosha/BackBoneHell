using UnityEngine;
using UnityEngine.Events;
using UnityTools.Extentions;

public class WorldWeaponComponent : MonoBehaviour
{
    [field: SerializeField] public WeaponData weapon { get; private set; }

    public readonly UnityEvent<WorldWeaponComponent> PlayerEntered = new UnityEvent<WorldWeaponComponent>();

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = weapon.discplaySprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.HasComponent<PlayerComponent>())
        {
            PlayerEntered?.Invoke(this);
        }
    }
}
