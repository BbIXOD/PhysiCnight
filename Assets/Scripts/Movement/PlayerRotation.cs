using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler), typeof(Rigidbody2D), typeof(PlayerMoveData))]
public class PlayerRotation : MonoBehaviour
{
    private const float offset = -90;
    private InputHandler _input;
    private Rigidbody2D _playerRb;
    private PlayerMoveData _data;

    private void Awake() {
        _input = GetComponent<InputHandler>();
        _playerRb = GetComponent<Rigidbody2D>();
        _data = GetComponent<PlayerMoveData>();
    }

    private void FixedUpdate() {
        var angle = GetRotationAmount(_input.mousePos, _data.turnSpeed * Time.fixedDeltaTime);
        _playerRb.MoveRotation(_playerRb.rotation + angle);
    }

    private float GetRotationAmount(Vector3 pos, float maxAmount) {
        var direction = pos - transform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + offset;
        var deltaAngle = Mathf.DeltaAngle(_playerRb.rotation, angle);

        deltaAngle = Mathf.Clamp(deltaAngle, -maxAmount, maxAmount);
        return deltaAngle;
    }
}
