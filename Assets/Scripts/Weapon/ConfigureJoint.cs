using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureJoint : MonoBehaviour
{

    private void Start() {
        var joint = GetComponent<RelativeJoint2D>();
        var data = GetComponent<WeaponData>();
        var rb = GetComponent<Rigidbody2D>();

        joint.autoConfigureOffset = false;
        joint.enableCollision = false;
        joint.maxForce = data.info.jointForce;
        joint.maxTorque = data.info.jointTorque;
        joint.correctionScale = data.info.jointCorScale;
        
        var offset = data.info.positionOffset;
        offset.x *= data.isLeftHand ? -1 : 1;

        joint.angularOffset = 0;
        joint.linearOffset = offset;

        rb.TeleportTo(offset, 0); //TODO: move
    }
}
