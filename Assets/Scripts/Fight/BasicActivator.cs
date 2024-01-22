using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BasicActivator : Activator
{
    private bool _isReady = true;
    [SerializeField] private int rechargeTime;

    private void Awake() {
        usables = GetComponents<IUsable>();
    }

    public override async void Recharge()
    {
        _isReady = false;
        await Task.Delay(rechargeTime);
        _isReady = true;
    }

    protected override bool CheckIsReady()
    {
        return _isReady;
    }
}
