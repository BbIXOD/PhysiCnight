using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureJoint : MonoBehaviour
{
    private RelativeJoint2D _joint;
    private WeaponData _data;

    private void Start() {
        _joint = GetComponent<RelativeJoint2D>();
        _data = GetComponent<WeaponData>();

        _joint.autoConfigureOffset = false;
        _joint.enableCollision = true;
        _joint.maxForce = _data.jointForce;
        _joint.maxTorque = _data.jointTorque;
        _joint.correctionScale = _data.jointCorScale;
    }
}
