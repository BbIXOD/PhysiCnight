using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StabAction : BasicAction
{
    [SerializeField]private float force;
    private Rigidbody2D _rb;
    private RelativeJoint2D _joint;
    private Transform _parentTr;
    private Vector2 _basicOffset;
    private float _forwardOffset;

    private IEnumerator Start() {
        _parentTr = transform.parent;
        _rb = GetComponent<Rigidbody2D>();
        _joint = GetComponent<RelativeJoint2D>();

        yield return new WaitForFixedUpdate();
        _basicOffset = _joint.linearOffset;
    }
    
    private void FixedUpdate() {
        if (!active) return;
        _forwardOffset += force * Time.fixedDeltaTime;

        _joint.linearOffset = _basicOffset - new Vector2(0, _forwardOffset) * Time.fixedDeltaTime;
    }

    protected override void StartAction()
    {
        base.StartAction();
        _forwardOffset = 0;
    }
}
