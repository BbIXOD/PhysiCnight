using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class BasicAction : MonoBehaviour, IUsable
{
    [SerializeField]protected int delay, duration;

    protected bool active = false;

    public async void Use() {
        await Task.Delay(delay);
        StartAction();
        await Task.Delay(duration);
        FinishAction();
    }

    protected virtual void StartAction() {
        active = true;
    }

    protected virtual void FinishAction() {
        active = false;
    }
}
