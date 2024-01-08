using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShieldAction : BasicAction
{
    [SerializeField] private float rotationSpeed;
    private Rigidbody2D _rb;
    private Transform _parentTr;
    private float _rotationAngle;

    private void Start() {
        _parentTr = transform.parent;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (!active) return;
        _rotationAngle += rotationSpeed * Time.fixedDeltaTime;

        Quaternion rotation = Quaternion.Euler(0, 0, _rotationAngle);
        _rb.MoveRotation(_parentTr.rotation * rotation);
    }

    protected override void StartAction() {
        base.StartAction();
        _rotationAngle = 0;
    }
}
