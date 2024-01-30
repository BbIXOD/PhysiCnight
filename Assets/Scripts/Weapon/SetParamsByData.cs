using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParamsByData : MonoBehaviour
{
    [SerializeField]private ParamSettable<int> damage;
    [SerializeField]private ParamSettable<float> force;
    private void Start() {
        var info = GetComponent<WeaponData>().info;
        if (damage != null) damage.param = info.damage;
        if (force != null) force.param = info.cnockback;
    }
}
