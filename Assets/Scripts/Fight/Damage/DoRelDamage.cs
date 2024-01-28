using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoRelDamage : MonoBehaviour
{
    [SerializeField]private int damageMultiplier = 1;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<IDamagable>(out var damagable)) {
            damagable.TakeDamage(damageMultiplier * (int)collision.relativeVelocity.magnitude);
        }
    }
}
