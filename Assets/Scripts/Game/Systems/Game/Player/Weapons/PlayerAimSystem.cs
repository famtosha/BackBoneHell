using UnityEngine;

public class PlayerAimSystem : GameSystem
{
    private PlayerComponent player => gameData.player;
    private Transform aimRoot => player.aimRoot.transform;

    private bool _left;

    public override void OnUpdate()
    {
        RotatePlayer();
        RotateGun();
    }

    private void RotatePlayer()
    {
        var mousePositionOnScreen = Input.mousePosition;
        var center = Screen.currentResolution.width / 2;
        _left = mousePositionOnScreen.x > center;
        if (_left)
        {
            player.transform.localScale = Vector3.one;
        }
        else
        {
            var scale = Vector3.one;
            scale.x *= -1;
            player.transform.localScale = scale;
        }
    }

    private void RotateGun()
    {
        var cursorPositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var playerPosition = player.transform.position;
        playerPosition.z = 0;
        cursorPositionInWorld.z = 0;
        var direction = cursorPositionInWorld - playerPosition;
        aimRoot.right = _left ? direction : -direction;
    }
}