using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StabAction : BasicAction
{
    [SerializeField]private float force;
    private Rigidbody2D _rb;
    private Transform _parentTr;
    private Vector3 _basicOffset;
    private float _forwardOffset;

    private void Start() {
        _parentTr = transform.parent;
        _rb = GetComponent<Rigidbody2D>();

        _basicOffset = transform.localPosition;
    }
    
    private void FixedUpdate() {
        if (!active) return;
        _forwardOffset += force * Time.fixedDeltaTime;

        _rb.MovePosition(_parentTr.TransformPoint(_basicOffset) + _parentTr.up * _forwardOffset);
    }

    protected override void StartAction()
    {
        base.StartAction();
        _forwardOffset = 0;
    }
}
