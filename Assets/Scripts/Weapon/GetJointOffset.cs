using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetJointOffset : MonoBehaviour
{
    public Vector2 offset;

    private void FixedUpdate() {
        offset = GetComponent<RelativeJoint2D>().linearOffset;
        enabled = false;
    }
}
