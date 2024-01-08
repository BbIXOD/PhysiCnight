using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Cycle))]
public class Spikes : MonoBehaviour
{
    private Cycle _cycle;
    private Collider2D _collider;

    private void Awake() {
        _cycle = GetComponent<Cycle>();
        _cycle.OnCycle += OnCycle;
        _collider = GetComponent<Collider2D>();
    }

    private void OnCycle() {
        _collider.enabled = !_collider.enabled;
    }
}
