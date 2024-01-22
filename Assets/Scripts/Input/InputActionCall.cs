using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputActionCall : MonoBehaviour
{
    [NonSerialized]public InputHandler input;
    [NonSerialized]public WeaponData data;
    [NonSerialized]public Activator activator;

    private void Start() {
        data = GetComponent<WeaponData>();
        activator = GetComponent<Activator>();
    }

    public void FixedUpdate() {
        if (data.isLeftHand ? input.leftHand : input.rightHand) {
            Debug.Log("Activate");
            activator.TryActivate();
        }
    }
}
