using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoForce : MonoBehaviour
{
    [SerializeField] private float force = 10.0f;

    private void OnTriggerEnter2D(Collider2D collision) {
        Do(collision.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Do(collision.transform);
    }

    private void Do(Transform other) {
        if (other.TryGetComponent<Rigidbody2D>(out var rb)) {
            var pushVector = (other.position - transform.position).normalized;
            rb.AddForce(pushVector * force);
        }
    }
}
