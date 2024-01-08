using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PemoveColForSync : MonoBehaviour
{
    private void Awake() {
        if (PhotonNetwork.IsMasterClient) return;
        var colliders = GetComponentsInChildren<Collider2D>();
        foreach (var col in colliders) {
            Destroy(col);
        }
    }
}
