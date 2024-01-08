using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class CooldownUsable : MonoBehaviour, IUsable
{
    [SerializeField]private int cooldown;

    private bool ready = true;

    public void Use() {
        if (!ready) return;
        Action();
        ready = false;
        Recharge();
    }

    private async void Recharge() {
        await Task.Delay(cooldown);
        ready = true;
    }

    protected abstract void Action();
}
