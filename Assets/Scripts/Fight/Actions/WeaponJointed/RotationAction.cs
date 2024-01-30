using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotationAction : MoveAction<float>
{
    public bool mirror = true;

    private void FixedUpdate() {
        if (!active) return;
        progress += Time.fixedDeltaTime * speed;

        joint.angularOffset = Mathf.Lerp(basicOffset, finalOffset, progress);
    }

    protected override void SetParams() {
        basicOffset = joint.angularOffset;
        if (!mirror) return;
        finalOffset *= GetComponent<WeaponData>().isLeftHand ? -1 : 1;
    }
}
