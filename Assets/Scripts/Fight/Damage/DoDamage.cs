using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDamage : ParamSettable<int>
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        Do(col);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Do(collision.collider);
    }

    private void Do(Collider2D col) {
        if (col.gameObject.TryGetComponent<IDamagable>(out var damagable))
        {
            damagable.TakeDamage(param);
        }
    }
}
