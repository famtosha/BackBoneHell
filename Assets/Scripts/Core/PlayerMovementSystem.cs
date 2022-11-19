using UnityEngine;

public class PlayerMovementSystem : GameSystemBase
{
    private PlayerMovementComponent movement => gameData.player.movement;

    public override void OnUpdate()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        var delta = input * Time.deltaTime * movement.movementSpeed;
        var newPoition = gameData.player.transform.position += delta;
        gameData.player.movement.rb.MovePosition(newPoition);
    }
}