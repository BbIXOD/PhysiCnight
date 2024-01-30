using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Invinsibility : MonoBehaviour
{
    [SerializeField]private int invTime = 500;
    private Health _health;
    private void Awake() {
        _health = GetComponent<Health>();
        _health.onTakeDamage += Action;
    }

    private async void Action(int _) {
        _health.enabled = false;
        await Task.Delay(invTime);
        if (this == null || _health == null) return;
        _health.enabled = true;
    }
}
