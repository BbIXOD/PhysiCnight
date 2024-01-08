using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class RemoveRbForSync : MonoBehaviour
{
    private void Awake() {
        if (PhotonNetwork.IsMasterClient) return;
        Destroy(GetComponent<Rigidbody>());
    }
}
