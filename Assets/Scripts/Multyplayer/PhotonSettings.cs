using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PhotonSettings : MonoBehaviour
{
    private void Awake() {
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
    }
}
