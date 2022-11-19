using UnityEngine;

public class PlayerAimSystem : GameSystem
{
    private PlayerComponent player => gameData.player;
    private Transform aimRoot => player.aimRoot.transform;

    public override void OnUpdate()
    {
        var cursorPositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var playerPosition = player.transform.position;
        playerPosition.z = 0;
        cursorPositionInWorld.z = 0;
        var direction = cursorPositionInWorld - playerPosition;
        aimRoot.up = direction;
    }
}