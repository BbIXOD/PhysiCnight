using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponInfo", menuName = "ScriptableObjects/WeaponInfo", order = 1)]
public class WeaponInfo : ScriptableObject
{
    public float jointForce = 1000, jointTorque = 1000, jointCorScale = 0.3f;

    public Vector2 positionOffset = new(0.6f, 0);
    public int damage, cnockback;
}
