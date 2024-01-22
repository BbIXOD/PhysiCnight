using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
[RequireComponent(typeof(WeaponData))]
public abstract class Activator: MonoBehaviour
{
    [SerializeField]protected IUsable[] usables;

    public void TryActivate() {
        if (!CheckIsReady()) return;

        foreach (var usable in usables) {
            usable.Use();
        }

        Recharge();
    }

    public abstract void Recharge();

    protected abstract bool CheckIsReady();
}
