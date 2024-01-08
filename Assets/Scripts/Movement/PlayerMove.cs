using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputHandler), typeof(PlayerMoveData), typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    private InputHandler _input;
    private PlayerMoveData _data;
    private Rigidbody2D _playerRb;

    private void Awake() {
        _input = GetComponent<InputHandler>();
        _data = GetComponent<PlayerMoveData>();
        _playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (_input.moveDir == Vector2.zero) return;

        var direction = _input.moveDir;
        
        CheckAccelerationPossible(_playerRb.velocity.x, _data.maxSpeed, ref direction.x);
        CheckAccelerationPossible(_playerRb.velocity.y, _data.maxSpeed, ref direction.y);

        direction = direction.normalized;
        _playerRb.AddForce(direction * _data.acceleration);
    }

    private void CheckAccelerationPossible(float current, float max, ref float acceleration) {
        acceleration = Mathf.Abs(current) > max 
            && Mathf.Sign(current) == Mathf.Sign(acceleration) ? 0 : acceleration;
    }
}
