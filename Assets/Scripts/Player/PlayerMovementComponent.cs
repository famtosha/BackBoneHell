using UnityEngine;

public class PlayerMovementComponent : MonoBehaviour
{
    [field: SerializeField] public float movementSpeed { get; private set; }

    public Rigidbody2D rb { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
