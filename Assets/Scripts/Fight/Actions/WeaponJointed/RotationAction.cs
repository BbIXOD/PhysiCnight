using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotationAction : MoveAction<float>
{
    private void FixedUpdate() {
        if (!active) return;
        progress += Time.fixedDeltaTime * speed;

        //TODO: move slerp for performance?
        joint.angularOffset = Mathf.Lerp(basicOffset, finalOffset, progress);
    }

    protected override void SetParams() {
        basicOffset = joint.angularOffset;
        //finalOffset *= GetComponent<WeaponData>().isLeftHand ? 1 : -1;
    }
}
