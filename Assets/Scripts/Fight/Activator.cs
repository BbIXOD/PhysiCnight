using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(WeaponData))]
public class Activator : MonoBehaviour
{
    private bool leftHand;
    [SerializeField]private IUsable[] usables;
    public InputHandler input;
    [SerializeField]private int cooldown = 1000;
    private bool _ready = true;

    private void Start() {
        usables ??= GetComponents<IUsable>();
        input ??= transform.root.GetComponent<InputHandler>();

        leftHand = GetComponent<WeaponData>().isLeftHand;
    }

    private void Update() {
        if (!_ready || !(leftHand ? input.leftHand : input.rightHand)) return; //TODO: separate input from else

        foreach (var usable in usables) {
            usable.Use();
        }

        Recharge();

    }

    private async void Recharge() {
        _ready = false;
        await Task.Delay(cooldown);
        _ready = true;
    }
}
