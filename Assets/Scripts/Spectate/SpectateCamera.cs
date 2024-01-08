using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectateCamera : Spectate
{
    protected override void Awake() {
        spectator = Camera.main.transform;
        base.Awake();
    }
}
