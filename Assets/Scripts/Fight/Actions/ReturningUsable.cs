using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ReturningUsable : BasicAction
{
    private const float ToSeconds = 0.001f;
    private float _returnTime;
    private float _elapsed;
    private Collider2D _collider;

    private Vector3 _startPos;
    private Quaternion _startRot;

    public void Awake()
    {
        _startPos = transform.localPosition;
        _startRot = transform.localRotation;
        _collider = GetComponent<Collider2D>();
        _returnTime = duration * ToSeconds;
    }

    private void Update() {
        if (!active) return;
        _elapsed += Time.deltaTime;
        var localPos = Vector3.MoveTowards(transform.localPosition, _startPos, _elapsed / _returnTime);
        var localRot = Quaternion.Lerp(transform.localRotation, _startRot, _elapsed / _returnTime);
        
        transform.SetLocalPositionAndRotation(localPos, localRot);
    }

    protected override void StartAction() {
        base.StartAction();
        _elapsed = 0;
    }
}
