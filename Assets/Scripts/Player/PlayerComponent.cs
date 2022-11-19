using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    [field: SerializeField] public PlayerMovementComponent movement { get; private set; }
}
