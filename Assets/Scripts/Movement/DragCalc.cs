using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DragCalc : MonoBehaviour
{
    [SerializeField]private int injureTime = 1000;
    private Rigidbody2D _rb;
    private PlayerMoveData _data;
    private Health _health;
    private InputHandler _input;
    private bool _injured = false;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _data = GetComponent<PlayerMoveData>();
        _health = GetComponent<Health>();
        _input = GetComponent<InputHandler>();
    }

    private void FixedUpdate() {
        if (_injured) return;

        _rb.drag = _input.moveDir == Vector2.zero ? _data.idleDrag : _data.moveDrag;
    }

    private async void Action() {
        _injured = true;
        _rb.drag = _data.onDamageDrag;
        await Task.Delay(injureTime);
        _injured = false;
    }
}
