using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoForce : MonoBehaviour
{
    [SerializeField] private float force = 10.0f;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.TryGetComponent<Rigidbody2D>(out var rb)) {
            var pushVector = (collision.transform.position - transform.position).normalized;
            Debug.Log(pushVector);
            rb.AddForce(pushVector * force);
        }
    }
}
