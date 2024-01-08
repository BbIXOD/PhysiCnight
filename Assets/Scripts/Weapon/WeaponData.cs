using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    [NonSerialized]public bool isLeftHand;

    public float jointForce = 1000, jointTorque = 1000;
    public float jointCorScale = 0.3f;
}
