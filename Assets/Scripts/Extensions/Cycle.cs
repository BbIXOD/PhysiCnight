using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    [SerializeField]private int changeRate = 1000;
    [NonSerialized]public Action OnCycle;

    private void Awake() {
        DoCycle();
    }

    private async void DoCycle() {
        while (true) {
            await Task.Delay(changeRate);
            if (this == null) break;
            OnCycle?.Invoke();
        }
    }
}
