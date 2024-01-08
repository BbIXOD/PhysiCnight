using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ReturningUsable : BasicAction
{
    private const float ToSeconds = 0.001f;
    private float _returnTime;
    private float _elapsed;

    private RelativeJoint2D _joint;

    private Vector2 _startPos;
    private Quaternion _startRot;

    public IEnumerator Start()
    {
        _joint = GetComponent<RelativeJoint2D>();

        yield return null;
        _startPos = _joint.linearOffset;
        _startRot = Quaternion.Euler(0, 0, _joint.angularOffset);
        _returnTime = duration * ToSeconds;
    }

    private void Update() {
        if (!active) return;
        _elapsed += Time.deltaTime;
        _joint.linearOffset = Vector2.MoveTowards(_joint.linearOffset, _startPos, _elapsed / _returnTime);
        //var localRot = Quaternion.Lerp(Quaternion.Euler(0, 0, _joint.angularOffset), _startRot, _elapsed / _returnTime);
        //_joint.angularOffset = localRot.eulerAngles.z;
    }

    protected override void StartAction() {
        base.StartAction();
        _elapsed = 0;
    }
}
