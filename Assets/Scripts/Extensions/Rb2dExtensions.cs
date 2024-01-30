using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rb2dExtensions {
    public static IEnumerator TeleportTo(this Rigidbody2D rb, Vector2 position, float rotation) {
        rb.simulated = false;
        yield return new WaitForFixedUpdate();
        rb.transform.SetPositionAndRotation(position, Quaternion.Euler(0, 0, rotation));
        yield return new WaitForFixedUpdate();
        rb.simulated = true;   
    }
}
