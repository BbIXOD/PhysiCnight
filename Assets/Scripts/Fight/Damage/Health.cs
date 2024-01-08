using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    public int maxHealth;
    public int currentHealth;

    public Action<int> onTakeDamage;
    public Action onDeath;

    private void Awake() {
        Review();
    }

    public void Review() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        onTakeDamage?.Invoke(damage);
        if (currentHealth > 0) return;
        onDeath?.Invoke();
    }
}
