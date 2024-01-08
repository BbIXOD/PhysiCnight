using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Friction : MonoBehaviour
{
    [Range(0, 1)]public float friction = 0.5f;
    private Rigidbody2D _rb;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        _rb.AddForce(-_rb.velocity * friction);
    }
}
