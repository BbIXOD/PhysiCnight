using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveAction<T> : BasicAction
{
    protected Rigidbody2D rb;
    protected RelativeJoint2D joint;
    protected Transform parentTr;
    protected T basicOffset;
    [SerializeField]protected T finalOffset;
    protected float speed;
    protected float progress;

    private IEnumerator Start() {
        parentTr = transform.parent;
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<RelativeJoint2D>();
        speed = Constants.MsToSeconds / duration;

        yield return new WaitForFixedUpdate();
        SetParams();
    }

    protected override void StartAction()
    {
        base.StartAction();
        progress = 0;
    }

    protected abstract void SetParams();
}
