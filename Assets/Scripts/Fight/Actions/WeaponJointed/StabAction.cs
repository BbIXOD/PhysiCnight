using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StabAction : MoveAction<Vector2>
{
    [SerializeField]protected bool slerp;
    
    private void FixedUpdate() {
        if (!active) return;
        progress += Time.fixedDeltaTime * speed;

        //TODO: move slerp for performance?
        joint.linearOffset = slerp ? Vector3.Slerp(basicOffset, finalOffset, progress) : Vector2.Lerp(basicOffset, finalOffset, progress);
    }

    protected override void SetParams() {
        basicOffset = joint.linearOffset;
        finalOffset.x *= GetComponent<WeaponData>().isLeftHand ? -1 : 1;
    }
}
