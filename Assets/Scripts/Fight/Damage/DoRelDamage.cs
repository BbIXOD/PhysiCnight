using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoRelDamage : ParamSettable<int>
{

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent<IDamagable>(out var damagable)) {
            damagable.TakeDamage(param * (int)collision.relativeVelocity.magnitude);
            Debug.Log(collision.relativeVelocity.magnitude * param);
        }
    }
}
