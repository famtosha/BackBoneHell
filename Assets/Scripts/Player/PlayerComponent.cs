using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    [field: SerializeField] public PlayerWeaponsComponent aimRoot { get; private set; }
    [field: SerializeField] public PlayerMovementComponent movement { get; private set; }
}
