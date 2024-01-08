using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CollidingUsable : BasicAction
{
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    protected override void StartAction()
    {
        base.StartAction();
        _collider.enabled = true;
    }

    protected override void FinishAction()
    {
        base.FinishAction();
        _collider.enabled = false;
    }


}
