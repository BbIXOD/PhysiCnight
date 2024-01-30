using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class DelayTrigger : MonoBehaviour
{
    [SerializeField]private int delay;
    [SerializeField]private bool activeInDelay;
    private bool _active = true;
    public UnityEvent OnTrigger;
    private async void OnTriggerEnter2D(Collider2D other) {
        if (!_active) return;
        _active = activeInDelay;
        await Task.Delay(delay);
        _active = true;
        OnTrigger?.Invoke();
    }
}
